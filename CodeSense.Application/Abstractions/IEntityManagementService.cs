using CodeSense.Domain.Abstractions;

namespace CodeSense.Application.Abstractions;

public interface IEntityManagementService<T> where T : EntityBase
{
    List<T> GetAll();

    T GetById(int id);

    T Create(T entity);

    T Update(T entity);

    void Delete(int id);
}