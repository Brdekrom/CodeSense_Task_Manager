namespace CodeSense.Domain.ValueObjects;

public record EmployeeFinancialData(int? DailySalary, int? DailyRate = 0)
{
    public int? Marge => DailyIncome - DailySalary;
    public bool IsProfitable => Marge > 0;
}