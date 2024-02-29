using CodeSense.Application.Abstractions;
using CodeSense.Application.Services;
using CodeSense.Domain.Entities;
using CodeSense.Infrastructure.Persistence;
using CodeSense.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSense.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CodeSenseDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IRepository<User>, UserRepository>();
        services.AddScoped<IRepository<Company>, CompanyRepository>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}