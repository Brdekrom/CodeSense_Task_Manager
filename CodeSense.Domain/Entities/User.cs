using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class User : EntityBase
{
    public int? ClientCompanyId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsEmailConfirmed { get; set;}
    
    // navigational properties
    public ClientCompany ClientCompany { get; set; }
}