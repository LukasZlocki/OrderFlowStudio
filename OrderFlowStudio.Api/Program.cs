using Microsoft.EntityFrameworkCore;
using OrderFlowStudio.Models;
using OrderFlowStudio.Services.Order_Service;
using OrderFlowStudio.Services.Product_Service;
using OrderFlowStudio.Services.Status_Service;
using OrderFlowStudio.Services.OrderReport_Service;
using OrderFlowStudio.Models.SeedDb;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.WriteIndented = true);

builder.Services.AddCors();

// Database configuration
builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<OrderDbContext>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderReportService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<StatusService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// auto seeding database if no data included in db.
SeedDb.SeedDatabase(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
