using CoR.Presentation.DAL;
using CoR.Presentation.Models;

namespace CoR.Presentation.ChainOfResponsibilityPattern
{
    public class BranchManagerAssistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            Context context = new Context();

            if (request.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount;
                customerProcess.CustomerName = request.CustomerName;
                customerProcess.EmployeeName = "Özge Bektaş";
                customerProcess.Description = "Müşterinin talep ettiği tutar Şube Müdür Yardımcısı tarafından ödendi";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount;
                customerProcess.CustomerName = request.CustomerName;
                customerProcess.EmployeeName = "Özge Bektaş";
                customerProcess.Description = "Müşterinin tarafından talep edilen tutar günlük ödeme bakiyemi aştığı için işlemi " +
                                              "şube müdürüne yönlendirdim";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(request);
            }
        }
    }
}