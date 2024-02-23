namespace CodeSense.Domain.ValueObjects;

public record Availability(DateOnly Start, DateOnly End)
{
    public bool IsAvailable => Start < DateOnly.FromDateTime(DateTime.Today) && End > DateOnly.FromDateTime(DateTime.Today);
}