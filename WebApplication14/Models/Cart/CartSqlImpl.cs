using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication14.Models.Cart
{
    public class CartSqlImpl : ICartRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CartSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Cart AddCart(Cart cart)
        {
            comm.CommandText = "insert into cart (BookId,Quantity,Status) values ('" + cart.BookId + "', '" + cart.Quantity + "', '" + cart.Status + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return cart;
            }
            else
            {
                return null;
            }
        }

        public string DeleteCart(int id)
        {
            comm.CommandText = "delete from Cart where CartId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();

            conn.Close();

            return "Cart having id " + id + " deleted";
        }

        public List<Cart> GetAllCart()
        {
            List<Cart> list = new List<Cart>();
            comm.CommandText = "select * from Cart";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int cid = Convert.ToInt32(reader["CartId"]);
                int bid = Convert.ToInt32(reader["BookId"]);
                int quant = Convert.ToInt32(reader["Quantity"]);

                bool status = Convert.ToBoolean(reader["Status"]);



                list.Add(new Cart(cid, bid,quant,status));
            }
            conn.Close();
            return list;
        }

        public string UpdateCart(int id, Cart cart)
        {
            comm.CommandText = "update Cart set BookId = '" + cart.BookId + "', Quantity = '" + cart.Quantity + "',   Status = '" + cart.Status + "' where CartId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            return "cart having id " + id + " is updated";
        }
    }
}