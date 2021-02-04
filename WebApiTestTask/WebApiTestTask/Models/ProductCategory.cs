using System.Collections.Generic;

namespace WebApiTestTask.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
