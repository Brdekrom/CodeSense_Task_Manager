using CodeSense.Domain.Entities;

namespace CodeSense.Application.Abstractions;

internal interface IAuthenticationHandlerService
{
    Task<bool> LoginAsync(User user);

    Task<bool> RegisterAsync(User user);

    Task<bool> UnregisterAsync(User user);
}