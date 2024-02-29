using CodeSense.Domain.Abstractions;
using CodeSense.Domain.Enums;
using CodeSense.Domain.ValueObjects;

namespace CodeSense.Domain.Entities;

public class Company(string vatNumber, string name, ContactData contactData, Address address, bool IsClient) : EntityBase
{
    public string VATNumber { get; private set; } = vatNumber;
    public string Name { get; private set; } = name;
    public ContactData ContactData { get; private set; } = contactData;
    public int MainAddressId { get; private set; }
    public Address MainAddress { get; private set; } = address;
    public FinancialData? FinancialData { get; private set; }
    public ICollection<Address> Addresses { get; private set; } = new List<Address>();
    public ICollection<User>? Users { get; private set; }
    public ICollection<Employee>? Employees { get; private set; }
    public ICollection<Project>? Projects { get; private set; }
    public ICollection<ProjectQuote>? ProjectQuotes { get; private set; }
    public bool IsClient { get; private set; } = IsClient;

    public Company() : this(string.Empty, string.Empty, new ContactData(string.Empty, string.Empty), new Address(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, EUCountries.BE), false)
    {
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void AddQuote(ProjectQuote projectQuote)
    {
        ProjectQuotes ??= new List<ProjectQuote>();

        ProjectQuotes.Add(projectQuote);
    }

    public void QuoteAccepted(Guid quoteId)
    {
        ProjectQuotes ??= new List<ProjectQuote>();
        var quote = ProjectQuotes.FirstOrDefault(x => x.Project.QuoteId == quoteId) ?? throw new Exception("Quote not found");
        quote.AcceptQuote();

        Projects ??= new List<Project>();
        Projects.Add(quote.Project);
    }

    public void AddEmployeeToProject(Employee employee, Project project)
    {
        employee.SetClientCompany(this);
        employee.SetProject(project);
    }

    public void UpdateFinancialData(FinancialData financialData)
    {
        FinancialData = financialData;
    }

    public void AddAddress(Address address)
    {
        if (address.IsPrimary)
        {
            MainAddress = address;
            return;
        }
        Addresses ??= new List<Address>();
        Addresses.Add(address);
    }

    public void AddAddresses(IEnumerable<Address> addresses)
    {
        var addressesList = Addresses?.ToList();
        addressesList ??= [];

        addressesList.AddRange(addresses);
        Addresses = addressesList;
    }

    public void AddUser(User user)
    {
        Users ??= new List<User>();

        Users.Add(user);
    }

    public void AddUsers(IEnumerable<User> users)
    {
        var usersList = Users?.ToList();
        usersList ??= [];

        usersList.AddRange(users);
        Users = usersList;
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

    public void AddProject(Project project)
    {
        Projects ??= new List<Project>();

        Projects.Add(project);

        Employees ??= new List<Employee>();
        foreach (var employee in project.Employees!)
        {
            employee.SetClientCompany(project.ClientCompany);
            employee.SetProject(project);
            Employees.Add(employee);
        }
    }

    public void AddProjects(IEnumerable<Project> projects)
    {
        var projectsList = Projects?.ToList();
        projectsList ??= [];

        projectsList.AddRange(projects);
        Projects = projectsList;
    }
}