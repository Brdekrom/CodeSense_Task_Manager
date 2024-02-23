using CodeSense.Domain.Abstractions;
using CodeSense.Domain.ValueObjects;

namespace CodeSense.Domain.Entities;

public class Project : EntityBase
{
    public int CompanyId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public FinancialData FinancialData { get; private set; }
    public DateOnly Deadline { get; private set; }
    public ICollection<Requirement>? Requirements { get; private set; }
    public ICollection<Employee>? Employees { get; private set; }
    public bool IsCompleted { get; private set; }

    // navigational properties
    public Company Company { get; set; }

    public void SetCompany(Company clientCompany)
    {
        Company = clientCompany;
        CompanyId = clientCompany.Id;
    }

    public void SetProjectInfo(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public void SetFinancialData(FinancialData financialData)
    {
        FinancialData = financialData;
    }

    public void SetDeadline(DateOnly deadline)
    {
        Deadline = deadline;
    }

    public void AddRequirement(Requirement requirement)
    {
        if (Requirements is null)
        {
            Requirements = new List<Requirement>();
        }

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
    }

    public void AddEmployees(IEnumerable<Employee> employees)
    {
        var employeesList = Employees?.ToList();
        employeesList ??= [];

        employeesList.AddRange(employees);
        Employees = employeesList;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }
}