using Microsoft.EntityFrameworkCore;

namespace CoR.Presentation.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-LVPTDQG\SQLEXPRESS; initial catalog= CasgemDbChainOfResponsibility; integrated security = true");
        }

        public DbSet<CustomerProcess> CustomerProcesses { get; set; }

    }
}