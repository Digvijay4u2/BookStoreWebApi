using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication14.Models
{
    public class OrderSqlImpl: IOrderRepository
    {
         SqlConnection conn;
        SqlCommand comm;

        public OrderSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Order AddOrder(Order order)
        {
            comm.CommandText = "insert into Orders (OrderStatus,UserId,Date,BookId) values ('" + order.OrderStatus + "', '" + order.UserId + "', '" + order.Date + "', '" + order.BookId + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return order;
            }
            else
            {
                return null;
            }
        }

       

        public List<Order> GetAllOrder()
        {
            List<Order> list = new List<Order>();
            comm.CommandText = "select * from Orders";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int oid = Convert.ToInt32(reader["OrderId"]);
                bool orderStatus = Convert.ToBoolean(reader["OrderStatus"]);
                int uid = Convert.ToInt32(reader["UserId"]);

                DateTime date = Convert.ToDateTime(reader["Date"]);
                int bid = Convert.ToInt32(reader["BookId"]);

                list.Add(new Order(oid,orderStatus,uid,date,bid));
            }
            conn.Close();
            return list;
        }

        public Order GetOrderById(int id)
        {
            Order order = new Order();
            comm.CommandText = "select * from Orders where OrderId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int oid = Convert.ToInt32(reader["OrderId"]);
                bool orderStatus = Convert.ToBoolean(reader["OrderStatus"]);
                int uid = Convert.ToInt32(reader["UserId"]);

                DateTime date = Convert.ToDateTime(reader["Date"]);
                int bid = Convert.ToInt32(reader["BookId"]);

                order = new Order(oid, orderStatus, uid, date, bid);
            }
            conn.Close();
            return order;
        }
        public Order GetOrderByUserId(int id)
        {
            Order order = new Order();
            comm.CommandText = "select * from Orders where OrderId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int oid = Convert.ToInt32(reader["OrderId"]);
                bool orderStatus = Convert.ToBoolean(reader["OrderStatus"]);
                int uid = Convert.ToInt32(reader["UserId"]);

                DateTime date = Convert.ToDateTime(reader["Date"]);
                int bid = Convert.ToInt32(reader["BookId"]);

                order = new Order(oid, orderStatus, uid, date, bid);
            }
            conn.Close();
            return order;
        }


    }
}