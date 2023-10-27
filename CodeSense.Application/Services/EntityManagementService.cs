using CodeSense.Application.Abstractions;
using CodeSense.Domain.Abstractions;

namespace CodeSense.Application.Services;

public class EntityManagementService<T> : IEntityManagementService<T> where T : EntityBase
{
    private readonly IRepository<T> _repository;

    public EntityManagementService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public List<T> GetAll()
    {
        return _repository.GetAll();
    }

    public T GetById(int id)
    {
        return _repository.GetById(id);
    }

    public T Create(T project)
    {
        _repository.Add(project);
        return project;
    }

    public T Update(T project)
    {
        _repository.Update(project);
        return project;
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}