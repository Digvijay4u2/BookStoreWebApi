using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication14.Models
{
    public class CoupanSqlImpl : ICoupanRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CoupanSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Coupan AddCoupan(Coupan coupan)
        {
            comm.CommandText = "insert into coupan (coupanName,Discount, Description,CategoryId) values ('" + coupan.CoupanName + "', '" + coupan.Discount + "', '" + coupan.Description + "', '" + coupan.CategoryId + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return coupan;
            }
            else
            {
                return null;
            }
        }

        public string DeleteCoupan(int id)
        {
            comm.CommandText = "delete from Coupan where CoupanId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();

            conn.Close();

            return "Coupan having id " + id + " deleted";
        }

        public List<Coupan> GetAllCoupan()
        {
            List<Coupan> list = new List<Coupan>();
            comm.CommandText = "select * from Coupan";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int cid = Convert.ToInt32(reader["CoupanId"]);
                int categoryid = Convert.ToInt32(reader["CategoryId"]);
                string coupanName = reader["coupanName"].ToString();
                string des = reader["Description"].ToString();
                decimal discount = Convert.ToDecimal(reader["Discount"]);
               
                

                list.Add(new Coupan(cid,categoryid,coupanName,des,discount));
            }
            conn.Close();
            return list;
        }

        public string UpdateCoupan(int id, Coupan coupan)
        {
            comm.CommandText = "update Coupan set CoupanName = '" + coupan.CoupanName + "', Discount = '" + coupan.Discount + "',   Description = '" + coupan.Description+ "',  CategoryId = '" + coupan.CategoryId + "' where CoupanId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            return "coupan having id " + id + " is updated";
        }
    }
}