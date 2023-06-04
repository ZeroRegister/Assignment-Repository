using Microsoft.EntityFrameworkCore;


namespace OrderAPI.Models
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; } 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Goods> Goods { get; set; } 
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
    
    
}
