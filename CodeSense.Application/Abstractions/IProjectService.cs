using CodeSense.Domain.DTOs;

namespace CodeSense.Application.Abstractions;

public interface IProjectService
{
    List<EmployeeDTO> Handle(ProjectDTO requirements);
}