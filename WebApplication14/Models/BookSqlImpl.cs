using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStoreApi.Models
{
    public class BookSqlImpl : IBookRepository
    {

        SqlConnection conn;
        SqlCommand comm;

        public BookSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Book AddBook(Book book)
        {
            comm.CommandText = "insert into Books (CategoryId,Title,Author,ISBN,Year,Price,Description,Position,Status,Image) values ('" + book.CategoryId + "', '" + book.Title + "', '"+book.Author+"', '" + book.ISBN + "', '" + book.Year + "' , '" + book.Price + "','" + book.Description + "','" + book.Position + "','" + book.Status + "','" + book.Image + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return book;
            }
            else
            {
                return null;
            }
        }

       

        public List<Book> GetAllBook()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Books";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int Bid = Convert.ToInt32(reader["BookId"]);
                int Cid = Convert.ToInt32(reader["CategoryId"]);
                string Title = reader["Title"].ToString();
                string Author = reader["Author"].ToString();
                string isbn = reader["ISBN"].ToString();
                string year = reader["Year"].ToString();
                decimal price = Convert.ToDecimal(reader["Price"]);
                string des = reader["Description"].ToString();

                int pos = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);

                string Img = reader["Image"].ToString();
                list.Add(new Book(Bid, Cid, Title,Author, isbn, year, price, des, pos, status, Img));
            }
            conn.Close();
            return list;
        }

        public Book GetBookById(int id)
        {
          //  List<Book> list = new List<Book>();
            Book book= new Book();
            comm.CommandText = "select * from Books where BookId = "+ id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int Bid = Convert.ToInt32(reader["BookId"]);
                int Cid = Convert.ToInt32(reader["CategoryId"]);
                string Title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                string isbn = reader["ISBN"].ToString();
                string year = reader["Year"].ToString();
                decimal price = Convert.ToDecimal(reader["Price"]);
                string des = reader["Description"].ToString();

                int pos = Convert.ToInt32(reader["Position"]);
                bool status = Convert.ToBoolean(reader["Status"]);
                string Img = reader["Image"].ToString();
                book = new Book(Bid, Cid, Title,author, isbn, year, price, des, pos, status, Img);
            }
            conn.Close();
            return book;
        }

        public string UpdateBook(int id,Book book)
        {
            comm.CommandText = "update Books set CategoryId = '" + book.CategoryId + "', Title = '" + book.Title +"',Author = '"+book.Author+"',  ISBN = '" + book.ISBN + "',  Year = '" + book.Year + "',  Price = '" + book.Price + "',  Description = '" + book.Description + "', Position = '" + book.Position + "' ,Status = '" + book.Status + "', Image = '" + book.Image + "' where BookId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            return "Category having id " + id + " is updated";
        }


        public string DeleteBook(int id)
        {
            comm.CommandText = "delete from Books where BookId = " + id ;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();

            conn.Close();

            return "Book having id " + id + " deleted";
        }

        public string searchBookByTitle(string title)
        {
            return "searching";
        }
    }
}