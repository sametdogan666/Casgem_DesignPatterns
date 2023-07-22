using CoR.Presentation.Models;

namespace CoR.Presentation.ChainOfResponsibilityPattern
{
    public abstract class Employee
    {
        protected Employee NextApprover;

        public void SetNextApprover(Employee supervisor)
        {
            this.NextApprover = supervisor;
        }

        public abstract void ProcessRequest(CustomerProcessViewModel request);

    }
}