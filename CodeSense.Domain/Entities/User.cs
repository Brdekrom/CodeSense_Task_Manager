using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class User : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}