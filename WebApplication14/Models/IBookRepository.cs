using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreApi.Models
{
    public interface IBookRepository
    {
        List<Book> GetAllBook();
        Book GetBookById(int id);
        Book AddBook(Book book);
        string DeleteBook(int id);
        string UpdateBook(int id,Book book);

        string searchBookByTitle(string title);
    }
}