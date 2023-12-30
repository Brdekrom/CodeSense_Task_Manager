using CodeSense.Domain.Entities;

namespace CodeSense.Application.Abstractions;

public interface IAuthentication
{
    Task<bool> LoginAsync(User user);

    Task<bool> RegisterAsync(User user);

    Task<bool> UnregisterAsync(User user);
}