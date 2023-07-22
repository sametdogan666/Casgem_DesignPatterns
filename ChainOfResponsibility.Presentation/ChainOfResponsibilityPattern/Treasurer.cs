using CoR.Presentation.DAL;
using CoR.Presentation.Models;

namespace CoR.Presentation.ChainOfResponsibilityPattern
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            Context context = new Context();
            if (request.Amount <= 50000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount;
                customerProcess.CustomerName = request.CustomerName;
                customerProcess.EmployeeName = "Mert Cagla";
                customerProcess.Description = "Müşterinin talep ettiği tutar veznedar tarafından ödendi";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount;
                customerProcess.CustomerName = request.CustomerName;
                customerProcess.EmployeeName = "Mert Cagla";
                customerProcess.Description = "Müşterinin tarafından talep edilen tutar günlük ödeme bakiyemi aştığı için işlemi " +
                                              "şube müdür yardımcısına yönlendirdim";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(request);

            }
        }
    }
}