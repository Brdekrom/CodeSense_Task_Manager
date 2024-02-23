namespace CodeSense.Domain.ValueObjects;

public record FinancialData(int? Budget, int? Cost)
{
    public int? Profit => Budget - Cost;
    public bool IsProfitable => Profit > 0;
}