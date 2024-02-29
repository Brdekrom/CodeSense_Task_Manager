using CodeSense.Domain.Enums;

namespace CodeSense.Domain.ValueObjects;

public record Address(string Street, string HouseNumber, string Box, string City, string State, string ZipCode, EUCountries Country, bool IsPrimary = false);