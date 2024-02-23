using CodeSense.Domain.Abstractions;
using CodeSense.Domain.ValueObjects;

namespace CodeSense.Domain.Entities;

public class User : EntityBase
{
    public int? ClientCompanyId { get; private set; }
    private UserContactData UserContactData { get; set; }
    private LoginData LoginData { get; set; }
    public bool IsAdmin { get; private set; }

    // navigational properties
    public Company ClientCompany { get; set; }

    public User(UserContactData contactData, LoginData loginData, bool isAdmin)
    {
        UserContactData = contactData;
        LoginData = loginData;
        IsAdmin = isAdmin;
    }

    public string GetEmail()
    {
        return LoginData.Email;
    }

    public string GetFullName()
    {
        return $"{UserContactData.FirstName} {UserContactData.LastName}";
    }

    public void SetCompany(Company company)
    {
        ClientCompanyId = company.Id;
        ClientCompany = company;
    }

    public void ChangeEmail(string email)
    {
        LoginData = LoginData with { Email = email };
    }

    public void ChangePassword(string password)
    {
        LoginData = LoginData with { Password = password };
    }

    public void SetAdminStatus(bool isAdmin)
    {
        IsAdmin = isAdmin;
    }
}