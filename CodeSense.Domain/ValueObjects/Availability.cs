namespace CodeSense.Domain.ValueObjects;

public record Availability(DateOnly From, DateOnly? Until = null)
{
    public bool IsAvailable
        => Until is null || From <= DateOnly.FromDateTime(DateTime.Today) && Until >= DateOnly.FromDateTime(DateTime.Today);
}