using CoR.Presentation.DAL;
using CoR.Presentation.Models;

namespace CoR.Presentation.ChainOfResponsibilityPattern
{
    public class RegionalManager:Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            Context context = new Context();

            if (request.Amount <= 300000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount;
                customerProcess.CustomerName = request.CustomerName;
                customerProcess.EmployeeName = "Hakan Bahşiş";
                customerProcess.Description = "Müşterinin talep ettiği tutar Bölge Müdürü tarafından ödendi";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = request.Amount;
                customerProcess.CustomerName = request.CustomerName;
                customerProcess.EmployeeName = "Hakan Bahşiş";
                customerProcess.Description = "Müşterinin tarafından talep edilen tutar günlük ödeme bakiyemi aştığı için işlem gerçekleştirilemedi";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

            }
        }
    }
}