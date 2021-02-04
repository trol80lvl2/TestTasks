using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiTestTask.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public double TotalCost { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public string Comment { get; set; }
    }
}
