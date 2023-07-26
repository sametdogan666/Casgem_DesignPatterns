using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Business.Abstract;
using UnitOfWork.Entities.Concrete;

namespace UnitOfWork.WebUI.Controllers;

public class DefaultController : Controller
{
    private readonly ICustomerProcessService _customerProcessService;
    private readonly ICustomerService _customerService;

    public DefaultController(ICustomerProcessService customerProcessService, ICustomerService customerService)
    {
        _customerProcessService = customerProcessService;
        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(CustomerProcess customerProcess)
    {
        var valueSender = _customerService.GetById(customerProcess.SenderId);
        var valueReceiver = _customerService.GetById(customerProcess.ReceiverId);

        valueReceiver.Balance += customerProcess.Amount;
        valueSender.Balance -= customerProcess.Amount;

        List<Customer> modifiedCustomer = new List<Customer>()
        {
            valueSender,
            valueReceiver
        };

        if (ModelState.IsValid)
        {
            _customerService.MultiUpdate(modifiedCustomer);
            _customerProcessService.Insert(customerProcess);
        }


        return RedirectToAction("Index");
    }
}