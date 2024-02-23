namespace CodeSense.Domain.ValueObjects;

public class EmployeeFinancialData
{
    public int? DailySalary { get; set; }
    public int? DailyIncome { get; set; }
    public int? Marge => DailyIncome - DailySalary;
    public bool IsProfitable => Marge > 0;
}