using CodeSense.Application.Abstractions;
using CodeSense.Application.Services;
using CodeSense.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSense.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProjectService, ProjectQuoteService>()
                .AddSingleton<JwtSettings>()
                .AddSingleton<TokenService>();

        return services;
    }
}