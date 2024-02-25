using Microsoft.EntityFrameworkCore;
using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Models
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderReport> OrderReports { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionStatus> Statuses { get; set; }
    }
}
