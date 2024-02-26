using CodeSense.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSense.Infrastructure.Data;

public static class DbInitializer
{
    public static void SeedDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CodeSenseDbContext>();
        Seed(context);
    }

    private static void Seed(CodeSenseDbContext context)
    {
        throw new NotImplementedException();
    }
}