using CodeSense.Application.Abstractions;
using CodeSense.Application.Services;
using CodeSense.Domain.Entities;
using CodeSense.Infrastructure.Persistence;
using CodeSense.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSense.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<DbContext, CodeSenseDbContext>();

        // services.AddScoped<IProjectService, ProjectService>();

        return services;
    }
}