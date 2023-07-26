using UnitOfWork.DataAccess.Abstract;
using UnitOfWork.DataAccess.Concrete;

namespace UnitOfWork.DataAccess.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly Context _context;

    public GenericRepository(Context context)
    {
        _context = context;
    }

    public void Insert(T entity)
    {
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void MultiUpdate(List<T> entities)
    {
        _context.UpdateRange(entities);
    }
}