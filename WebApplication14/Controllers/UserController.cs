using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class UserController : ApiController
    {

        private IUserRepository repository;
           
        public UserController()
        {
            repository = new UserSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetUserById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllUser();
            return Ok(data);
        }





        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            var data = repository.AddUser(user);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(repository.DeleteUser(id));
        }

        [HttpPut]

        public IHttpActionResult Put(int id, User user)
        {

            return Ok(repository.UpdateUser(id, user));
        }
    }
}
