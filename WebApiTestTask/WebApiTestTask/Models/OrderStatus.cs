using System.Collections.Generic;

namespace WebApiTestTask.Models
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
