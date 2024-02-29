using CodeSense.Domain.Abstractions;
using CodeSense.Domain.ValueObjects;

namespace CodeSense.Domain.Entities;

public class User(UserContactData contactData, LoginData loginData, bool isAdmin) : EntityBase
{
    public int? ClientCompanyId { get; private set; }
    private UserContactData UserContactData { get; set; } = contactData;
    private LoginData LoginData { get; set; } = loginData;
    public bool IsAdmin { get; private set; } = isAdmin;

    // navigational properties
    public Company ClientCompany { get; set; }

    public User() : this(new UserContactData(), new LoginData(string.Empty, string.Empty, false), false)
    {
    }

    public string GetEmail()
    {
        return LoginData.Email;
    }

    public string GetHashedPassword()
    {
        return LoginData.Password;
    }

    public string UpdatePassword(string newPassword)
    {
        LoginData = LoginData with { Password = newPassword };
        return LoginData.Password;
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