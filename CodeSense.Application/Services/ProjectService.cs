using CodeSense.Application.Abstractions;
using CodeSense.Domain.Abstractions;
using CodeSense.Domain.Entities;

namespace CodeSense.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IRepository<Project> _repository;

    public ProjectService(IRepository<Project> repository)
    {
        _repository = repository;
    }

    public List<Project> GetAllProjects()
    {
        return _repository.GetAll();
    }

    public Project GetProjectById(int id)
    {
        return _repository.GetById(id);
    }

    public Project CreateProject(Project project)
    {
        _repository.Add(project);
        return project;
    }

    public Project UpdateProject(Project project)
    {
        _repository.Update(project);
        return project;
    }

    public void DeleteProject(int id)
    {
        _repository.Delete(id);
    }
}