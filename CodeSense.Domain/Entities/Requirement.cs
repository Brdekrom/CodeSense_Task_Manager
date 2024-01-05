using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class Requirement : EntityBase
{
    public int ProjectId { get; set; }
    public string Position { get; set; }
    public int RequiredEmployees { get; set; }
}