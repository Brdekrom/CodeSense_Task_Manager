namespace CodeSense.Application.Services;

using CodeSense.Application.Abstractions;
using CodeSense.Domain.Common.Enum;
using CodeSense.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

public class ProjectQuoteService(IRepository<Company> repository) : IProjectService
{
    private Company _consultancy;
    private readonly IRepository<Company> _repository = repository;

    public async Task<Project> HandleAsync(Project project)
    {
        if (project is null)
        {
            throw new ValidationException("Project is null");
        }
        await GetConsultancy(project.ConsultancyId);

        var availableEmployees = GetAvailableEmployees();
        var employeesByLevel = SortEmployeesByLevel(availableEmployees);
        var selectedEmployees = new List<Employee>();

        if (project.Requirements is null)
        {
            throw new NullReferenceException("No Employee available for this project");
        }

        var requirements = project.Requirements.OrderByDescending(x => x.RequiredEmployees.Level);

        foreach (var requirement in requirements)
        {
            if (employeesByLevel.TryGetValue(requirement.RequiredEmployees.Level, out List<Employee>? employeesOfLevel))
            {
                var employeesToTake = Math.Min(employeesOfLevel.Count, requirement.RequiredEmployees.Quantity);
                var chosenEmployees = employeesOfLevel.Take(employeesToTake);
                selectedEmployees.AddRange(chosenEmployees);
                employeesOfLevel.RemoveRange(0, employeesToTake);
                requirement.RequiredEmployees = requirement.RequiredEmployees with { Quantity = requirement.RequiredEmployees.Quantity - employeesToTake };
            }

            if (requirement.RequiredEmployees.Quantity > 0)
            {
                GetNextHigherLevel(requirement.RequiredEmployees.Level, requirement.RequiredEmployees.Quantity, employeesByLevel, selectedEmployees);
            }
        }

        if (selectedEmployees.Count == 0)
        {
            throw new NullReferenceException("No Employee available for this project");
        }

        var employees = selectedEmployees
            .ToList();

        return PopulateProject(project, employees);
    }

    private static Project PopulateProject(Project project, List<Employee> employees)
    {
        project.AddEmployees(employees);
        return project;
    }

    private static IDictionary<EmployeeLevel, List<Employee>> SortEmployeesByLevel(IList<Employee> employees) => employees
                .GroupBy(employee => employee.Level)
                .ToDictionary(x => x.Key, x => x.ToList());

    private List<Employee> GetAvailableEmployees()
    {
        if (_consultancy.Employees is null)
        {
            throw new NullReferenceException("No Employee available for this project");
        }

        var availableEmployees = _consultancy.Employees
                                    .Where(employee => employee.Availability.IsAvailable)
                                    .ToList();

        if (availableEmployees.Count == 0)
        {
            throw new NullReferenceException("No Employee available for this project");
        }

        return availableEmployees;
    }

    private static void GetNextHigherLevel(EmployeeLevel requiredLevel, int requiredAmount, IDictionary<EmployeeLevel, List<Employee>> employeesByLevel, List<Employee> employeeList)
    {
        while (requiredAmount > 0)
        {
            var nextHigherLevel = NextHigherLevel(requiredLevel);

            if (string.IsNullOrEmpty(nextHigherLevel.ToString()) || !employeesByLevel.ContainsKey(nextHigherLevel))
            {
                break;
            }

            var higherLevelEmployees = employeesByLevel[nextHigherLevel];
            var toTake = Math.Min(higherLevelEmployees.Count, requiredAmount);
            var choosenEmployees = higherLevelEmployees.Take(toTake);
            employeeList.AddRange(choosenEmployees);
            higherLevelEmployees.RemoveRange(0, toTake);
            requiredAmount -= toTake;
        }
    }

    private static EmployeeLevel NextHigherLevel(EmployeeLevel currentLevel)
        => currentLevel switch
        {
            EmployeeLevel.Senior => EmployeeLevel.Architect,
            EmployeeLevel.Medior => EmployeeLevel.Senior,
            EmployeeLevel.Junior => EmployeeLevel.Medior,
            _ => currentLevel
        };

    private async Task GetConsultancy(int id)
    {
        _consultancy = await _repository.GetByIdAsync(id);
        if (_consultancy is null)
        {
            throw new NullReferenceException("Company not found");
        }
    }
}