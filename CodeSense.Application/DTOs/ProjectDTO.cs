namespace CodeSense.Domain.DTOs;

public class ProjectDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Budget { get; set; }
    public int Cost { get; set; }
    public int Profit { get; set; }
    public DateOnly Deadline { get; set; }
    public List<RequirementDTO> Requirements { get; set; }
}