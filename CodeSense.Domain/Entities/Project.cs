using CodeSense.Domain.Abstractions;
using CodeSense.Domain.ValueObjects;

namespace CodeSense.Domain.Entities;

public class Project(string name, Company company, ProjectDates projectDates) : EntityBase
{
    public int CompanyId { get; private set; } = company.Id;
    public string Name { get; private set; } = name;
    public string? Description { get; private set; }
    public FinancialData? FinancialData { get; private set; }
    public ProjectDates ProjectDates { get; private set; } = projectDates;
    public ICollection<Requirement>? Requirements { get; private set; }
    public ICollection<Employee>? Employees { get; private set; }
    public bool IsCompleted { get; private set; } = false;

    // navigational properties
    public Company Company { get; set; } = company;

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void RenameProject(string newName)
    {
        Name = newName;
    }

    public void SetFinancialData(FinancialData financialData)
    {
        if (!financialData.IsProfitable)
        {
            throw new Exception("This project is not profitable");
        }

        FinancialData = financialData;
    }

    public void SetProjectDates(ProjectDates dates)
    {
        ProjectDates = dates;
    }

    public void UpdateDeadline(DateOnly deadline)
    {
        ProjectDates = ProjectDates with { EndDate = deadline };
    }

    public void AddRequirement(Requirement requirement)
    {
        Requirements ??= new List<Requirement>();

        Requirements.Add(requirement);
    }

    public void AddRequirements(IEnumerable<Requirement> requirements)
    {
        var requirementsList = Requirements?.ToList();
        requirementsList ??= [];

        requirementsList.AddRange(requirements);
        Requirements = requirementsList;
    }

    public void AddEmployee(Employee employee)
    {
        Employees ??= new List<Employee>();

        Employees.Add(employee);

        CalculateProjectCost();
    }

    public void AddEmployees(IEnumerable<Employee> employees)
    {
        var employeesList = Employees?.ToList();
        employeesList ??= [];

        employeesList.AddRange(employees);
        Employees = employeesList;

        CalculateProjectCost();
    }

    private void CalculateProjectCost()
    {
        if (FinancialData is null)
        {
            throw new Exception("There is no financial data available for the project");
        }

        var totalDailyCost = Employees!.Sum(employee => employee.FinancialData!.DailySalary);
        FinancialData = FinancialData with { Cost = totalDailyCost };
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }
}