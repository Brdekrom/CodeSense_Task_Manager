namespace CodeSense.Application.Services;

using AutoMapper;
using CodeSense.Application.Abstractions;
using CodeSense.Domain.Common.Enum;
using CodeSense.Domain.DTOs;
using CodeSense.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

public class ProjectHandlerService(IMapper mapper, IValidator<Project> projectValidator) : IProjectService
{
    // Add employee service after creating it
    private readonly IMapper _mapper = mapper;

    private readonly IValidator<Project> _projectValidator = projectValidator;

    public List<EmployeeDTO> Handle(ProjectDTO projectDto)
    {
        var project = MapAndValidate(projectDto);

        var availableEmployees = GetAvailableEmployees();

        var employeesByLevel = SortEmployeesByLevel(availableEmployees);

        var employeeList = new List<Employee>();

        foreach (var requirement in project.Requirements)
        {
            if (employeesByLevel.TryGetValue(requirement.RequiredEmployees.Level.ToString(), out List<Employee>? employeesOfLevel))
            {
                var employeesToTake = Math.Min(employeesOfLevel.Count, requirement.RequiredEmployees.Quantity);
                var chosenEmployees = employeesOfLevel.Take(employeesToTake);
                employeeList.AddRange(chosenEmployees);
                employeesOfLevel.RemoveRange(0, employeesToTake);
                requirement.RequiredEmployees = requirement.RequiredEmployees with { Quantity = requirement.RequiredEmployees.Quantity - employeesToTake };
            }

            if (requirement.RequiredEmployees.Quantity > 0)
            {
                GetNextHigherLevel(requirement.RequiredEmployees.Level, requirement.RequiredEmployees.Quantity, employeesByLevel, employeeList);
            }
        }

        if (!employeeList.Any())
        {
            throw new NullReferenceException("No Employee available for this project");
        }

        var employees = employeeList
            .Select(_mapper.Map<EmployeeDTO>)
            .ToList();

        return employees;
    }

    private Project MapAndValidate(ProjectDTO project)
    {
        var mappedProject = _mapper.Map<Project>(project);

        var validationResult = _projectValidator.Validate(mappedProject);

        if (!validationResult.IsValid)
        {
            throw new ValidationException("validation failed", validationResult.Errors);
        }

        return mappedProject;
    }

    private static IDictionary<string, List<Employee>> SortEmployeesByLevel(IList<Employee> employees)
    => employees
            .GroupBy(employee => employee.Level.ToString())
            .ToDictionary(x => x.Key, x => x.ToList());

    private List<Employee> GetAvailableEmployees()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        return new List<Employee>();

        //_employeeService
        //.GetAll()
        //.Where(x => x.AvailableFrom <= today && x.AvailableUntil >= today)
        //.ToList();
    }

    private static void GetNextHigherLevel(EmployeeLevel requiredLevel, int requiredAmount, IDictionary<string, List<Employee>> employeesByLevel, List<Employee> employeeList)
    {
        while (requiredAmount > 0)
        {
            var nextHigherLevel = NextHigherLevel(requiredLevel);

            if (string.IsNullOrEmpty(nextHigherLevel.ToString()) || !employeesByLevel.ContainsKey(nextHigherLevel.ToString()))
            {
                break;
            }

            var higherLevelEmployees = employeesByLevel[nextHigherLevel.ToString()];
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
            EmployeeLevel.Junior => EmployeeLevel.Medior,
            EmployeeLevel.Medior => EmployeeLevel.Senior,
            EmployeeLevel.Senior => EmployeeLevel.Architect,
            _ => currentLevel
        };
}