using CodeSense.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CodeSense.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInMemoryDatabase(this IServiceCollection services)
    {
        services.AddDbContext<CodeSenseDbContext>(options => options.UseInMemoryDatabase("MyInMemoryDb"));
        return services;
    }
}
