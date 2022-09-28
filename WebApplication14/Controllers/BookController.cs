using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Web.Http;
using BookStoreApi.Models;
using Newtonsoft.Json;

namespace BookStoreApi.Controllers
{
    
   
    public class BookController : ApiController
    {
        private IBookRepository repository;

        public BookController()
        {
            repository = new BookSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetBookById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllBook();
            return Ok(data);
        }





        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            var data = repository.AddBook(book);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(repository.DeleteBook(id));
        }

        [HttpPut]

        public IHttpActionResult Put(int id, Book book)
        {

            return Ok(repository.UpdateBook(id, book));
        }

        [HttpGet]
        [Route("search/{Title}")]
        public IHttpActionResult Search(string Title)
        {
            var httpResponseMessage = new HttpResponseMessage();
            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(repository.searchBookByTitle(Title)));
            repository.searchBookByTitle(Title);
            return Ok();
        }


    }
}
