using Microsoft.EntityFrameworkCore;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
        {
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRaport> OrderRaports { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionStatus> Statuses {get; set;}
        
    }
}