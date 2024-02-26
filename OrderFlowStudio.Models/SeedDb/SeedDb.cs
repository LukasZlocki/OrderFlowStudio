using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Models.SeedDb
{
    public static class SeedDb
    {
        public static void SeedDatabase(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<OrderDbContext>());
            }
        }

        public static void SeedData(OrderDbContext context)
        {
            System.Console.WriteLine("Appling migration to OrderFLowStudio db.");
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                System.Console.WriteLine("Adding products to OrderFLowStudio db.");
                context.Products.AddRange(
                    new Product() { PartNumber = "111A1111", ProductDescription = "Motor OMP" },
                    new Product() { PartNumber = "111A2222", ProductDescription = "Motor OMR" },
                    new Product() { PartNumber = "111A3333", ProductDescription = "Motor OMH" },
                    new Product() { PartNumber = "111A4444", ProductDescription = "Motor OMM" },
                    new Product() { PartNumber = "111A5555", ProductDescription = "Motor OMEW" },
                    new Product() { PartNumber = "111A6666", ProductDescription = "Motor OMW" }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Product data exist - no need to seed.");
            }
            

            if (!context.Statuses.Any())
            {
                System.Console.WriteLine("Adding statuses to OrderFLowStudio db.");
                context.Statuses.AddRange(
                    new ProductionStatus() { StatusCode = 10, StatusDescription = "Not started" },
                    new ProductionStatus() { StatusCode = 20, StatusDescription = "Masking" },
                    new ProductionStatus() { StatusCode = 30, StatusDescription = "Processing" },
                    new ProductionStatus() { StatusCode = 40, StatusDescription = "Correction" },
                    new ProductionStatus() { StatusCode = 50, StatusDescription = "Packing" },
                    new ProductionStatus() { StatusCode = 60, StatusDescription = "Finished" }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Statuses data exist - no need to seed.");
            }

            if (!context.Orders.Any())
            {
                System.Console.WriteLine("Adding orders to OrderFLowStudio db.");
                context.Orders.AddRange(
                    new Order() { OrderNumber = 10101010, Quantity = 60, ProductId = 1, ReportId = 1 },
                    new Order() { OrderNumber = 20202020, Quantity = 25, ProductId = 2, ReportId = 2 },
                    new Order() { OrderNumber = 30303030, Quantity = 30, ProductId = 3, ReportId = 3 },
                    new Order() { OrderNumber = 40404040, Quantity = 40, ProductId = 4, ReportId = 4 },
                    new Order() { OrderNumber = 50505050, Quantity = 50, ProductId = 5, ReportId = 5 }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Orders data exist - no need to seed.");
            }
            

            if (!context.OrderReports.Any())
            {
                System.Console.WriteLine("Adding order reports to OrderFLowStudio db.");
                context.OrderReports.AddRange(
                    new OrderReport() { QuantityFinished = 58, StatusId = 1 },
                    new OrderReport() { QuantityFinished = 23, StatusId = 2 },
                    new OrderReport() { QuantityFinished = 28, StatusId = 3 },
                    new OrderReport() { QuantityFinished = 36, StatusId = 4 },
                    new OrderReport() { QuantityFinished = 47, StatusId = 5 }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("OrderReports data exist - no need to seed.");
            }
        }
    }
}
