using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStoreApi.Models;


namespace BookStoreApi.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepository repository;

        public CategoryController()
        {
            repository = new CategorySqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategory();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetCategoryById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpDelete]
          public IHttpActionResult Delete(int id)
           {
               

            string data =   repository.DeleteCategory(id);
            return Ok(data);
           }


           [HttpPut]

           public IHttpActionResult Put(int id,Category category)
           {
               
            return Ok(repository.UpdateCategory(id, category));
           }
  

        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            var data = repository.AddCategory(category);
            return Ok(data);
        }

    }
}
