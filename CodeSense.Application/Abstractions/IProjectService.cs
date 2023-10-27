using CodeSense.Domain.Entities;

namespace CodeSense.Application.Abstractions;

public interface IProjectService
{
    List<Employee> RetrieveAvailableEmployees(List<Requirement> requirements);
}