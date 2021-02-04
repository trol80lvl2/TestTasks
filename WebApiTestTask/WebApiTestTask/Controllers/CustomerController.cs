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
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly WebApiContext _context;

        public CustomerController(ILogger<CustomerController> logger, WebApiContext context)
        {
            _logger = logger;
            _context = context;
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        //public IEnumerable<Customer> Get(int? id)
        //{
        //    return _context.Customers.Where(c => c.CustomerId == id).ToList();
        //}
        [HttpGet]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            return Ok(_context.Customers.Where(p => p.CustomerId == id).FirstOrDefault());
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public ActionResult AddCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            return Ok(_context.SaveChanges());
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public ActionResult DeleteProductById(int id)
        {
            _context.Customers.Remove(_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
            return Ok(_context.SaveChanges());
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public ActionResult DeleteProductById(Customer newCustomer)
        {
            Customer customer = _context.Customers.Where(x => x.CustomerId == newCustomer.CustomerId).FirstOrDefault();
            customer = newCustomer;
            return Ok(_context.SaveChanges());
        }

    }
}
