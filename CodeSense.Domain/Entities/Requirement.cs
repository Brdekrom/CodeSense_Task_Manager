using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class Requirement : EntityBase
{
    public string Position { get; set; }
    public int RequiredEmployees { get; set; }
}