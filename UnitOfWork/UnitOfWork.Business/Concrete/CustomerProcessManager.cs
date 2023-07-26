using UnitOfWork.Business.Abstract;
using UnitOfWork.DataAccess.Abstract;
using UnitOfWork.DataAccess.UnitOfWork.Abstract;
using UnitOfWork.Entities.Concrete;

namespace UnitOfWork.Business.Concrete;

public class CustomerProcessManager : ICustomerProcessService
{
    private readonly ICustomerProcessDal _customerProcessDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;

    public CustomerProcessManager(ICustomerProcessDal customerProcessDal, IUnitOfWorkDal unitOfWorkDal)
    {
        _customerProcessDal = customerProcessDal;
        _unitOfWorkDal = unitOfWorkDal;
    }

    public void Insert(CustomerProcess entity)
    {
        _customerProcessDal.Insert(entity);
        _unitOfWorkDal.Save();
    }

    public void Update(CustomerProcess entity)
    {
       _customerProcessDal.Update(entity);
       _unitOfWorkDal.Save();
    }

    public void Delete(CustomerProcess entity)
    {
        _customerProcessDal.Delete(entity);
        _unitOfWorkDal.Save();
    }

    public List<CustomerProcess> GetAll()
    {
        return _customerProcessDal.GetAll();
    }

    public CustomerProcess? GetById(int id)
    {
        return _customerProcessDal.GetById(id);
    }

    public void MultiUpdate(List<CustomerProcess> entities)
    {
        _customerProcessDal.MultiUpdate(entities);
        _unitOfWorkDal.Save();
    }
}