using CodeSense.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeSense.Infrastructure.Persistence;

public class CodeSenseDbContext : DbContext
{
    public CodeSenseDbContext(DbContextOptions<CodeSenseDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
}
