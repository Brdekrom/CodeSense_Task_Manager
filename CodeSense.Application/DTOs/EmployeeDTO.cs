namespace CodeSense.Domain.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Level { get; set; }
    public int Cost { get; set; }
    public DateOnly AvailableFrom { get; set; }
    public DateOnly AvailableUntil { get; set; }
}