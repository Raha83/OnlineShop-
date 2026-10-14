using Microsoft.EntityFrameworkCore;

namespace Eshop
{
    public class EshopContext : DbContext
    {
        public DbSet<Customer> customers { get; set; } = null!;
        public DbSet<Order> orders { get; set; } = null!;
        public DbSet<OrderDetail> orderdetails { get; set; } = null!;
        public DbSet<Product> products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            "Server=localhost;Database=TodoDb;Trusted_Connection=True;TrustServerCertificate=True;"
             );
        }
    }

}
