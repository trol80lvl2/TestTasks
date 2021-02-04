using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTestTask.Models
{
    public class OrderProduct
    {
        public int OrderProductId { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }
        public int SizeId { get; set; }
        public Size? Size { get; set; }
    }
}
