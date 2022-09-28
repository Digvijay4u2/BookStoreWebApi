using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;
using BookStoreApi.Models;

namespace WebApplication14.Controllers
{
    public class AddressController : ApiController
    {
        private IAddressRepository repository;

        public AddressController()
        {
            repository = new AddressSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetAddressById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

       





        [HttpPost]
        public IHttpActionResult Post(Address address)
        {
            var data = repository.AddAddress(address);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(repository.DeleteAddress(id));
        }

        [HttpPut]

        public IHttpActionResult Put(int id, Address address)
        {

            return Ok(repository.UpdateAddress(id, address));
        }
    }
}
