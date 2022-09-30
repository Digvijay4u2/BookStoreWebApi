using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class CoupanController : ApiController
    {
        private ICoupanRepository repository;

        public CoupanController()
        {
            repository = new CoupanSqlImpl();
        }

       

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCoupan();
            return Ok(data);
        }





        [HttpPost]
        public IHttpActionResult Post(Coupan coupan)
        {
            var data = repository.AddCoupan(coupan);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(repository.DeleteCoupan(id));
        }

        [HttpPut]

        public IHttpActionResult Put(int id, Coupan coupan)
        {

            return Ok(repository.UpdateCoupan(id, coupan));
        }
    }
}
