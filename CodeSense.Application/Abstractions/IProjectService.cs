using CodeSense.Domain.Entities;

namespace CodeSense.Application.Abstractions;

public interface IProjectService
{
    Task<Project> HandleAsync(Project project);
}