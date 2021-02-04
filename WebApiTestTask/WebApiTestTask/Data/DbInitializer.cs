using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTestTask.Models;

namespace WebApiTestTask.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WebApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.ProductCategories.Any() || context.OrderStatuses.Any())
                return;

            var orderStatuses = new OrderStatus[]
            {
                new OrderStatus() { Name = "New" },
                new OrderStatus() { Name = "Paid" },
                new OrderStatus() { Name = "Shipped" },
                new OrderStatus() { Name = "Delivered" },
                new OrderStatus() { Name = "Closed" }
            };
            foreach (var os in orderStatuses)
                context.OrderStatuses.Add(os);
            context.SaveChanges();

            var productCategories = new ProductCategory[]
            {
                new ProductCategory() { Name = "Food" },
                new ProductCategory() { Name = "Medicine" },
                new ProductCategory() { Name = "Electronic" }
            };
            foreach (var ps in productCategories)
                context.ProductCategories.Add(ps);
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer() { Name = "John Smith", Address = "5th Ave, New York" }
            };
            foreach (var c in customers)
                context.Customers.Add(c);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product() { Name = "Pizza", AvailableQuantity = 50, CategoryId = 1, Price = 150 },
                new Product() { Name = "Pasta", AvailableQuantity = 100, CategoryId = 1, Price = 120 }
            };
            foreach (var p in products)
                context.Products.Add(p);
            context.SaveChanges();

            var sizes = new Size[]
            {
                new Size() { Name = "Small" },
                new Size() { Name = "Medium" },
                new Size() { Name = "Large" }
            };
            foreach (var s in sizes)
                context.Sizes.Add(s);
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order() { CustomerId = 1, OrderStatusId = 1, Comment = "first order" }
            };
            foreach (var o in orders)
                context.Orders.Add(o);
            context.SaveChanges();

            var orderProducts = new OrderProduct[]
            {
                new OrderProduct() { OrderId = 1, ProductId = 1, Quantity = 5, SizeId = 1 }
            };
            foreach (var op in orderProducts)
                context.OrderProducts.Add(op);
            context.SaveChanges();
        }
    }
}
