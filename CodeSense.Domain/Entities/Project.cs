using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class Project : EntityBase
{
    public int ClientCompanyId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Budget { get; set; }
    public int Cost { get; set; }
    public int Profit => Budget - Cost;
    public DateOnly Deadline { get; set; }
    public ICollection<Requirement> Requirements { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public bool IsCompleted { get; set; }

    // navigational properties
    public Company ClientCompany { get; set; }
}