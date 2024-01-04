using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class Project : EntityBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Budget { get; set; }
    public int Cost { get; set; }
    public int Profit => Budget - Cost;
    public DateOnly Deadline { get; set; }
    public List<Requirement> Requirements { get; set; }
    public List<Employee> Employees { get; set; }
}