using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class OrderController : ApiController
    {
        private IOrderRepository repository;

        public OrderController()
        {
            repository = new OrderSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetOrderById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllOrder();
            return Ok(data);
        }





        [HttpPost]
        public IHttpActionResult Post(Order order)
        {
            var data = repository.AddOrder(order);
            return Ok(data);
        }

        
    }
}
