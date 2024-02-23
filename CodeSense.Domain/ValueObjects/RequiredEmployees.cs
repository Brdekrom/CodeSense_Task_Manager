using CodeSense.Domain.Common.Enum;

namespace CodeSense.Domain.ValueObjects;

public record RequiredEmployees(EmployeeLevel Level, int Quantity);