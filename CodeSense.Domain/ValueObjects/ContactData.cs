namespace CodeSense.Domain.ValueObjects;

public record ContactData(string PrimaryEmail, ICollection<string>? SecondaryEmails, string PrimaryPhoneNumber, ICollection<string>? SecondaryPhoneNumbers);