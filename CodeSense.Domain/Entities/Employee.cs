using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class Employee : EntityBase
{
    public string Name { get; set; }
    public string Level { get; set; }
    public int Cost { get; set; }
    public DateOnly AvailableFrom { get; set; }
    public DateOnly AvailableUntil { get; set; }
}