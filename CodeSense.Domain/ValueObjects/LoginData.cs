namespace CodeSense.Domain.ValueObjects;

public record LoginData(string Email, string Password, bool IsEmailConfirmed);