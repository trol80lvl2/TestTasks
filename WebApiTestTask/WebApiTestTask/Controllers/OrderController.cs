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
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly WebApiContext _context;

        public OrderController(ILogger<OrderController> logger, WebApiContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Order[]), (int)HttpStatusCode.OK)]
        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public ActionResult<Customer> GetOrderById(int id)
        {
            return Ok(_context.Orders.Where(p => p.OrderId == id).FirstOrDefault());
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult AddOrder([FromBody] Order order)
        {
            _context.Orders.Add(order);
            return Ok(_context.SaveChanges());
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult AddOrderProduct([FromBody] OrderProduct orderProduct)
        {
            _context.OrderProducts.Add(orderProduct);
            return Ok(_context.SaveChanges());
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult DeleteOrderById(int id)
        {
            _context.Orders.Remove(_context.Orders.Where(x => x.OrderId == id).FirstOrDefault());
            return Ok(_context.SaveChanges());
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public ActionResult DeleteProductById(Order newOrder)
        {
            Order order = _context.Orders.Where(x => x.OrderId == newOrder.OrderId).FirstOrDefault();
            order = newOrder;
            return Ok(_context.SaveChanges());
        }
    }
}
