using CodeSense.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeSense.Infrastructure.Persistence;

public class CodeSenseDbContext(DbContextOptions<CodeSenseDbContext> options) : DbContext(options)
{
    public DbSet<ClientCompany> ClientCompanies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
}