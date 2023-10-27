using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class Requirement : EntityBase
{
    public string Level { get; set; }
    public int Amount { get; set; }
}