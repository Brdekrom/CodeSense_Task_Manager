namespace CodeSense.Domain.Abstractions;

public interface IRepository<T> where T : EntityBase
{
    List<T> GetAll();

    T GetById(int id);

    void Add(T entity);

    void Update(T entity);

    void Delete(int id);
}