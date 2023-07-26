using UnitOfWork.Business.Abstract;
using UnitOfWork.DataAccess.Abstract;
using UnitOfWork.DataAccess.UnitOfWork.Abstract;
using UnitOfWork.Entities.Concrete;

namespace UnitOfWork.Business.Concrete;

public class CustomerManager : ICustomerService
{
    private readonly ICustomerDal _customerDal;
    private readonly IUnitOfWorkDal _unitOfWorkDal;
    public CustomerManager(ICustomerDal customerDal, IUnitOfWorkDal unitOfWorkDal)
    {
        _customerDal = customerDal;
        _unitOfWorkDal = unitOfWorkDal;
    }

    public void Insert(Customer entity)
    {
        _customerDal.Insert(entity);
        _unitOfWorkDal.Save();
    }

    public void Update(Customer entity)
    {
        _customerDal.Update(entity);
        _unitOfWorkDal.Save();
    }

    public void Delete(Customer entity)
    {
        _customerDal.Delete(entity);
        _unitOfWorkDal.Save();
    }

    public List<Customer> GetAll()
    {
        return _customerDal.GetAll();
    }

    public Customer? GetById(int id)
    {
        return _customerDal.GetById(id);
    }

    public void MultiUpdate(List<Customer> entities)
    {
        _customerDal.MultiUpdate(entities);
        _unitOfWorkDal.Save();
    }
}