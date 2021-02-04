using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiTestTask.Data;
using WebApiTestTask.Models;

namespace WebApiTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly WebApiContext _context;

        public ProductController(ILogger<ProductController> logger, WebApiContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public ActionResult<Product> GetProductById(int id)
        {
            return Ok(_context.Products.Where(p => p.ProductId == id).FirstOrDefault());
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public ActionResult AddProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            return Ok(_context.SaveChanges());
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public ActionResult DeleteProductById(int id)
        {
            _context.Products.Remove(_context.Products.Where(x=>x.ProductId == id).FirstOrDefault());
            return Ok(_context.SaveChanges());
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public ActionResult DeleteProductById(Product newProduct)
        {
            Product product = _context.Products.Where(x => x.ProductId == newProduct.ProductId).FirstOrDefault();
            product = newProduct;
            return Ok(_context.SaveChanges());
        }
    }
}
