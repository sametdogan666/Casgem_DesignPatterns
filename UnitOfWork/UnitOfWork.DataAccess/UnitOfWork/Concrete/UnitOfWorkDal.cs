using UnitOfWork.DataAccess.Concrete;
using UnitOfWork.DataAccess.UnitOfWork.Abstract;

namespace UnitOfWork.DataAccess.UnitOfWork.Concrete;

public class UnitOfWorkDal : IUnitOfWorkDal
{
    private readonly Context _context;

    public UnitOfWorkDal(Context context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}