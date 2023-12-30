using CodeSense.Application.Abstractions;
using CodeSense.Domain.Abstractions;

namespace CodeSense.Application.Services;

public class EntityManagementService<T> : IEntityManagementService<T> where T : EntityBase
{
    public EntityManagementService()
    {
    }

    public List<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public T Create(T project)
    {
        throw new NotImplementedException();
    }

    public T Update(T project)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}