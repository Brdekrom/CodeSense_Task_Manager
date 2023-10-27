using CodeSense.Domain.Abstractions;
using CodeSense.Infrastructure.Persistence;

namespace CodeSense.Domain.Repositories;

public class EfCoreRepository<T> : IRepository<T> where T : EntityBase
{
    private readonly CodeSenseDbContext _context;

    public EfCoreRepository(CodeSenseDbContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().Where(x => !x.IsDeleted).ToList();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().FirstOrDefault(x => x.Id == id && !x.IsDeleted);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            entity.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}