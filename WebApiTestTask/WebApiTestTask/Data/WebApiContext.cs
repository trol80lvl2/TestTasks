using Microsoft.EntityFrameworkCore;
using WebApiTestTask.Models;

namespace WebApiTestTask.Data
{
    public class WebApiContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");
            modelBuilder.Entity<OrderStatus>().ToTable("OrderStatus");
            modelBuilder.Entity<Size>().ToTable("Size");
            modelBuilder.Entity<OrderProduct>().ToTable("OrderProduct");
        }
    }
}
