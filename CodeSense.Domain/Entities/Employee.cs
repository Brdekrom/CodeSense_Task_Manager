using CodeSense.Domain.Abstractions;
using CodeSense.Domain.Common.Enum;
using CodeSense.Domain.ValueObjects;

namespace CodeSense.Domain.Entities;

public class Employee(string firstName, string lastName, Company employerCompany, ContactData contactData, EmployeeLevel employeeLevel, EmployeeFinancialData employeeFinancialData) : EntityBase
{
    public int? ProjectId { get; private set; }
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public ContactData? ContactData { get; private set; } = contactData;
    public Company? EmployerCompany { get; private set; } = employerCompany;
    public EmployeeLevel Level { get; private set; } = employeeLevel;
    public EmployeeFinancialData? FinancialData { get; private set; } = employeeFinancialData;
    public Company? ClientCompany { get; private set; }
    public Availability Availability { get; private set; } = new Availability(DateOnly.FromDateTime(DateTime.Today));

    // navigational properties
    public Project? Project { get; private set; }

    public void SetClientCompany(Company clientCompany)
    {
        ClientCompany = clientCompany;
    }

    public int GetStandardDailyPrice()
    {
        if (FinancialData is null)
        {
            throw new Exception("There is no financial data available for the employee");
        }

        if (FinancialData.DailySalary is null)
        {
            throw new Exception("The daily salary is not set for the employee");
        }

        var dailyPrice = FinancialData.DailySalary * 1.15;

        return (int)dailyPrice;
    }

    public int SetDailyPrice(int price)
    {
        if (FinancialData is null)
        {
            throw new Exception("There is no financial data available for the employee");
        }

        if (price < FinancialData.DailySalary)
        {
            throw new Exception("The price cannot be lower than the daily salary");
        }

        FinancialData = FinancialData with { DailyIncome = price };

        return price;
    }

    public int SetDailyPriceByPercentage(int percentage)
    {
        if (FinancialData is null)
        {
            throw new Exception("There is no financial data available for the employee");
        }

        var dailyIncome = FinancialData.DailySalary * (1 + (percentage / 100));

        if (dailyIncome < FinancialData.DailySalary)
        {
            throw new Exception("The price cannot be lower than the daily salary");
        }

        FinancialData = FinancialData with { DailyIncome = dailyIncome };

        return (int)dailyIncome;
    }

    //TODO: Only Admins should be able to set the financial data
    public void SetDailySalary(int salary)
    {
        if (FinancialData is null)
        {
            throw new Exception("There is no financial data available for the employee");
        }

        FinancialData = FinancialData with { DailySalary = salary };
    }

    public void SetProject(Project project)
    {
        if (ClientCompany is null)
        {
            throw new Exception("There is no client company available");
        }
        if (project.ClientCompanyId != ClientCompany.Id)
        {
            throw new Exception("The project is not available for the client company");
        }

        Project = project;
        ProjectId = project.Id;

        Availability = new Availability(Availability.From, project.ProjectDates.StartDate);
    }

    //TODO: Only Admins should be able to set the contact data
    public void SetContactData(ContactData contactData)
    {
        ContactData = contactData;
    }

    public void SetAvailability(Availability availability)
    {
        Availability = availability;
    }

    //TODO: Only Admins should be able to set the financial data
    public void SetFinancialData(EmployeeFinancialData financialData)
    {
        FinancialData = financialData;
    }

    public void SetLevel(EmployeeLevel level)
    {
        Level = level;
    }
}