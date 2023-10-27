using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class Project : EntityBase
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Profit { get; set; }
    public DateOnly Deadline { get; set; }
    public List<Requirement> Requirements { get; set; }
}