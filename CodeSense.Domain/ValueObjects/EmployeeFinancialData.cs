namespace CodeSense.Domain.ValueObjects;

public record EmployeeFinancialData(int? DailySalary, int? DailyIncome)
{
    public int? Marge => DailyIncome - DailySalary;
    public bool IsProfitable => Marge > 0;
}