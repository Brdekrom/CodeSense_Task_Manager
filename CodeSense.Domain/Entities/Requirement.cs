using CodeSense.Domain.Abstractions;
using CodeSense.Domain.ValueObjects;

namespace CodeSense.Domain.Entities;

public class Requirement : EntityBase
{
    public int ProjectId { get; set; }
    public string Position { get; set; }
    public RequiredEmployees RequiredEmployees { get; set; }
}