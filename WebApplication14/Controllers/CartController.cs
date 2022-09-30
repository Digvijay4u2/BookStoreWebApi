using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models.Cart;

namespace WebApplication14.Controllers
{
    public class CartController : ApiController
    {
        private ICartRepository repository;

        public CartController()
        {
            repository = new CartSqlImpl();
        }



        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCart();
            return Ok(data);
        }





        [HttpPost]
        public IHttpActionResult Post(Cart cart)
        {
            var data = repository.AddCart(cart);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(repository.DeleteCart(id));
        }

        [HttpPut]

        public IHttpActionResult Put(int id, Cart cart)
        {

            return Ok(repository.UpdateCart(id, cart));
        }
    }
}
