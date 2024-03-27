using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Models
{
    public class OrderDbContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;

        public OrderDbContext(DbContextOptions<OrderDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderReport> OrderReports { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionStatus> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                // Use the connection string from appsettings.json
                string? connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);

                optionsBuilder.UseSqlServer(connectionString, options =>
                {
                    // Enable retry on failure
                    options.EnableRetryOnFailure();
                });
            }
        }
    }
}
