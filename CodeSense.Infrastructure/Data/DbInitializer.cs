using Bogus;
using CodeSense.Domain.Entities;
using CodeSense.Infrastructure.Persistence;

namespace CodeSense.Infrastructure.Data;

public static class DbInitializer
{
    public static void Seed(CodeSenseDbContext context)
    {
        if (context.Employees.Any())
        {
            return;
        }

        var levelNames = new[] { "Junior Developer", "Medior Developer", "Senior Developer", "Architect", "PM" };

        var faker = new Faker<Employee>()
            .RuleFor(o => o.Name, f => f.Name.FirstName())
            .RuleFor(o => o.Level, f => f.PickRandom(levelNames))
            .RuleFor(o => o.Cost, f => f.Random.Number(400, 700))
            .RuleFor(o => o.AvailableFrom, f => DateOnly.FromDateTime(f.Date.Past(1)))
            .RuleFor(o => o.AvailableUntil, f => DateOnly.FromDateTime(f.Date.Future(1)));

        var employees = faker.Generate(100);

        context.Employees.AddRange(employees);
        context.SaveChanges();
    }
}