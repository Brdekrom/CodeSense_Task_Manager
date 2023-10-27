namespace CodeSense.Application.Services;

using CodeSense.Application.Abstractions;
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

    public List<Employee> RetrieveAvailableEmployees(List<Requirement> requirements)
    {
        var availableEmployees = GetAvailableEmployees();

        var employeesByLevel = availableEmployees
            .GroupBy(employee => employee.Level)
            .ToDictionary(x => x.Key, x => x.ToList());

        var selectedEmployees = new List<Employee>();

        foreach (var requirement in requirements)
        {
            var requiredLevel = requirement.Level;
            var requiredAmount = requirement.Amount;

            if (employeesByLevel.ContainsKey(requiredLevel))
            {
                var employeesOfLevel = employeesByLevel[requiredLevel];

                var toTake = Math.Min(employeesOfLevel.Count, requiredAmount);
                selectedEmployees.AddRange(employeesOfLevel.Take(toTake));
                employeesOfLevel.RemoveRange(0, toTake);
                requiredAmount -= toTake;
            }

            while (requiredAmount > 0)
            {
                var nextHigherLevel = GetNextHigherLevel(requiredLevel);

                if (string.IsNullOrEmpty(nextHigherLevel) || !employeesByLevel.ContainsKey(nextHigherLevel))
                {
                    break;
                }

                var higherLevelEmployees = employeesByLevel[nextHigherLevel];
                var toTake = Math.Min(higherLevelEmployees.Count, requiredAmount);
                selectedEmployees.AddRange(higherLevelEmployees.Take(toTake));
                higherLevelEmployees.RemoveRange(0, toTake);
                requiredAmount -= toTake;
            }
        }

        return selectedEmployees;
    }

    private List<Employee> GetAvailableEmployees()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        return _employeeService
                            .GetAll()
                            .Where(x => x.AvailableFrom <= today && x.AvailableUntil >= today)
                            .ToList();
    }

    private static string GetNextHigherLevel(string currentLevel)
        => currentLevel switch
        {
            "Junior developer" => "Medior developer",
            "Medior developer" => "Senior developer",
            "Senior developer" => string.Empty,
            "Architect" => "Senior developer",
            _ => string.Empty
        };
}