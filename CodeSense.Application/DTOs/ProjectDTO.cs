namespace CodeSense.Domain.DTOs;

public class ProjectDTO
{
    public string Title { get; set; }
    public int Profit { get; set; }
    public DateOnly Deadline { get; set; }
    public List<RequirementDTO> Requirements { get; set; }
}