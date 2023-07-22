using Microsoft.EntityFrameworkCore;

namespace CQRS.Presentation.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=DESKTOP-LVPTDQG\SQLEXPRESS; initial catalog= CasgemDbCQRS; integrated security = true");
        }

        public DbSet<Product> Products { get; set; }

    }
}