namespace CodeSense.Domain.ValueObjects;

public record EmployeeFinancialData(int? DailySalary, int? DailyRate = 0)
{
    public int? Marge => DailyRate - DailySalary;
    public bool IsProfitable => Marge > 0;
}