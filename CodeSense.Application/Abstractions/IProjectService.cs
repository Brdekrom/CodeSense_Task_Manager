using CodeSense.Domain.Entities;

namespace CodeSense.Application.Abstractions;

public interface IProjectService
{
    Task<List<Employee>> RetrieveAvailableEmployeesAsync(List<Requirement> requirements);
}