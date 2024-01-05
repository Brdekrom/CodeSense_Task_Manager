using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class Employee : EntityBase
{
    public int ProjectId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public int Salary { get; set; }
    public ClientCompany? ClientCompany { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly AvailableFrom { get; set; }
    public DateOnly? AvailableUntil { get; set; }
    public bool IsAvailable { get; set; }

    // navigational properties

    public Project Project { get; set; }
}