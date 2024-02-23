namespace CodeSense.Domain.ValueObjects
{
    public record ProjectDates(DateOnly StartDate, DateOnly EndDate)
    {
        public bool IsInProgress => StartDate < DateOnly.FromDateTime(DateTime.Today) && EndDate > DateOnly.FromDateTime(DateTime.Today);
    }
}