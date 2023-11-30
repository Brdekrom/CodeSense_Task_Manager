namespace CodeSense.Application.Services;

using CodeSense.Application.Abstractions;
using CodeSense.Domain.Common.Constants;
using CodeSense.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

public class ProjectService : IProjectService
{
    private readonly IEntityManagementService<Employee> _employeeService;

    public ProjectService(IEntityManagementService<Employee> employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<List<Employee>> RetrieveAvailableEmployeesAsync(List<Requirement> requirements)
    {
        var employeesByLevel = await GetEmployeesByLevelAsync(await GetAvailableEmployeesAsync());

        var employeeList = new List<Employee>();

        foreach (var requirement in requirements)
        {
            if (employeesByLevel.ContainsKey(requirement.Level))
            {
                var employeesOfLevel = employeesByLevel[requirement.Level];

                var toTake = Math.Min(employeesOfLevel.Count, requirement.Amount);
                employeeList.AddRange(employeesOfLevel.Take(toTake));
                employeesOfLevel.RemoveRange(0, toTake);
                requirement.Amount -= toTake;
            }

            if (requirement.Amount > 0)
            {
                GetNextHigherLevel(requirement.Level, requirement.Amount, employeesByLevel, employeeList);
            }
        }

        return employeeList;
    }

    private async Task<IDictionary<string, List<Employee>>> GetEmployeesByLevelAsync(IList<Employee> employees)
    => employees
            .GroupBy(employee => employee.Level)
            .ToDictionary(x => x.Key, x => x.ToList());

    private async Task<List<Employee>> GetAvailableEmployeesAsync()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        return _employeeService
                            .GetAll()
                            .Where(x => x.AvailableFrom <= today && x.AvailableUntil >= today)
                            .ToList();
    }

    private void GetNextHigherLevel(string requiredLevel, int requiredAmount, IDictionary<string, List<Employee>> employeesByLevel, List<Employee> employeeList)
    {
        while (requiredAmount > 0)
        {
            var nextHigherLevel = NextHigherLevel(requiredLevel);

            if (string.IsNullOrEmpty(nextHigherLevel) || !employeesByLevel.ContainsKey(nextHigherLevel))
            {
                break;
            }

            var higherLevelEmployees = employeesByLevel[nextHigherLevel];
            var toTake = Math.Min(higherLevelEmployees.Count, requiredAmount);
            employeeList.AddRange(higherLevelEmployees.Take(toTake));
            higherLevelEmployees.RemoveRange(0, toTake);
            requiredAmount -= toTake;
        }
    }

    private static string NextHigherLevel(string currentLevel)
        => currentLevel switch
        {
            EmployeeLevel.Junior => EmployeeLevel.Medior,
            EmployeeLevel.Medior => EmployeeLevel.Senior,
            EmployeeLevel.Senior => EmployeeLevel.Architect,
            _ => string.Empty
        };
}