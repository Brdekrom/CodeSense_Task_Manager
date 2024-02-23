using CodeSense.Domain.Abstractions;
using CodeSense.Domain.ValueObjects;

namespace CodeSense.Domain.Entities;

public class Company(string name, ContactData contactData, Address address) : EntityBase
{
    public string Name { get; private set; } = name;
    public ContactData ContactData { get; private set; } = contactData;
    public Address MainAddress { get; private set; } = address;
    public ICollection<Address> Addresses { get; private set; } = new List<Address>();
    public ICollection<User>? Users { get; private set; }
    public ICollection<Employee>? Employees { get; private set; }
    public ICollection<Project>? Projects { get; private set; }

    public void UpdateName(string name)
    {
        Name = name;
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
    }

    public void AddProjects(IEnumerable<Project> projects)
    {
        var projectsList = Projects?.ToList();
        projectsList ??= [];

        projectsList.AddRange(projects);
        Projects = projectsList;
    }
}