using Microsoft.EntityFrameworkCore;

namespace Eshop
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options) : base(options) { }
        public DbSet<Customer> customers { get; set; } = null!;
        public DbSet<Order> orders { get; set; } = null!;
        public DbSet<OrderDetail> orderdetails { get; set; } = null!;
        public DbSet<Product> products { get; set; } = null!;

    }

}
