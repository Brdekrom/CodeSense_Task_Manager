namespace CodeSense.Domain.ValueObjects;

public record Address(string Street, string City, string State, string ZipCode, Country Country, bool IsPrimary = false);