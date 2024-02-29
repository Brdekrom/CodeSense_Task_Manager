using CodeSense.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeSense.Infrastructure.Persistence;

public class CodeSenseDbContext(DbContextOptions<CodeSenseDbContext> options) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.EmployerCompany)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.EmployerCompanyId);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.ClientCompany)
            .WithMany()
            .HasForeignKey(e => e.ClientCompanyId)
            .IsRequired(false);

        modelBuilder.Entity<Employee>()
            .OwnsOne(e => e.Availability);

        modelBuilder.Entity<Employee>()
            .OwnsOne(e => e.ContactData);

        modelBuilder.Entity<Employee>()
            .OwnsOne(e => e.FinancialData);

        modelBuilder.Entity<Employee>()
            .OwnsOne(e => e.FinancialData);

        modelBuilder.Entity<Company>()
            .OwnsOne(c => c.MainAddress);

        modelBuilder.Entity<Company>()
        .OwnsMany(c => c.Addresses);

        modelBuilder.Entity<Company>()
            .OwnsOne(c => c.ContactData);

        modelBuilder.Entity<Company>()
            .OwnsOne(c => c.FinancialData);

        modelBuilder.Entity<Project>()
            .OwnsOne(p => p.FinancialData);

        modelBuilder.Entity<Project>()
            .OwnsOne(p => p.ProjectDates);

        modelBuilder.Entity<Project>()
            .OwnsMany(p => p.Requirements)
            .OwnsOne(r => r.RequiredEmployees);
    }
}