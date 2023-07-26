using UnitOfWork.DataAccess.Abstract;
using UnitOfWork.DataAccess.Concrete;
using UnitOfWork.DataAccess.Repositories;
using UnitOfWork.Entities.Concrete;

namespace UnitOfWork.DataAccess.EntityFramework;

public class EfCustomerProcessDal : GenericRepository<CustomerProcess>, ICustomerProcessDal
{
    public EfCustomerProcessDal(Context context) : base(context)
    {
    }
}