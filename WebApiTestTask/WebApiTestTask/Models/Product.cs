using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiTestTask.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory? Category { get; set; }
        public int AvailableQuantity { get; set; }
        public double Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
