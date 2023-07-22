using CoR.Presentation.ChainOfResponsibilityPattern;
using CoR.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoR.Presentation.Controllers
{
    public class DefaultController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel customerProcessViewModel)
        {
            Employee treasurer = new Treasurer();
            Employee branchManagerAssistant = new BranchManagerAssistant();
            Employee branchManager = new BranchManager();
            Employee regionalManager = new RegionalManager();

            treasurer.SetNextApprover(branchManagerAssistant);
            branchManagerAssistant.SetNextApprover(branchManager);
            branchManager.SetNextApprover(regionalManager);

            treasurer.ProcessRequest(customerProcessViewModel);

            return View();
        }
    }
}