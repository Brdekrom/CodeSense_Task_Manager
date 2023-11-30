using CodeSense.Application.Abstractions;
using CodeSense.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSense.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IEntityManagementService<>), typeof(EntityManagementService<>))
                .AddScoped<IProjectService, ProjectService>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}