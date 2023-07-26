using Microsoft.EntityFrameworkCore;
using UnitOfWork.Entities.Concrete;

namespace UnitOfWork.DataAccess.Concrete;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options):base(options)
    {
        
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerProcess> CustomerProcesses { get; set; }

}