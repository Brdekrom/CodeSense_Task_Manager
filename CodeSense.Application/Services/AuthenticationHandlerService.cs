using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;

namespace CodeSense.Application.Services;

internal class AuthenticationHandlerService : IAuthenticationHandlerService
{
    public Task<bool> LoginAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegisterAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UnregisterAsync(User user)
    {
        throw new NotImplementedException();
    }
}