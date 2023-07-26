using UnitOfWork.DataAccess.Abstract;
using UnitOfWork.DataAccess.Concrete;
using UnitOfWork.DataAccess.Repositories;
using UnitOfWork.Entities.Concrete;

namespace UnitOfWork.DataAccess.EntityFramework;

public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
{
    public EfCustomerDal(Context context) : base(context)
    {
    }
}