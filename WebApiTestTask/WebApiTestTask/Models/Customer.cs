using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiTestTask.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
    }
}
