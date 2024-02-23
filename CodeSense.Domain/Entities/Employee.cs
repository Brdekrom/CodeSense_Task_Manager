using CodeSense.Domain.Abstractions;
using CodeSense.Domain.Common.Enum;
using CodeSense.Domain.ValueObjects;

namespace CodeSense.Domain.Entities;

public class Employee : EntityBase
{
    public int ProjectId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public EmployeeLevel Level { get; private set; }
    public EmployeeFinancialData FinancialData { get; private set; }
    public Company? ClientCompany { get; private set; }
    public ContactData ContactData { get; private set; }
    public Availability Availability { get; private set; }

    // navigational properties
    public Project Project { get; private set; }

    public void SetProject(Project project)
    {
        ProjectId = project.Id;
        Project = project;
    }

    public void SetCompany(Company company)
    {
        ClientCompany = company;
    }

    public void SetContactData(ContactData contactData)
    {
        ContactData = contactData;
    }

    public void SetAvailability(Availability availability)
    {
        Availability = availability;
    }

    public void SetFinancialData(EmployeeFinancialData financialData)
    {
        FinancialData = financialData;
    }

    public void SetLevel(EmployeeLevel level)
    {
        Level = level;
    }

    public void SetName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}