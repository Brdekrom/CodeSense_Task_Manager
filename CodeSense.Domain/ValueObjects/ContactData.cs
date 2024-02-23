namespace CodeSense.Domain.ValueObjects;

public record ContactData(string PrimaryEmail, string PrimaryPhoneNumber, ICollection<string>? SecondaryEmails = default, ICollection<string>? SecondaryPhoneNumbers = default);