using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication14.Models
{
    public class AddressSqlImpl : IAddressRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public AddressSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Address AddAddress(Address address)
        {
            

            comm.CommandText = "insert into Address (HouseNo,StreetName,City , pincode, UserId) values ('" + address.HouseNo + "', '" + address.StreetName + "', '" + address.city + "', '" + address.pincode + "' , '" + address.Userid + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return address;
            }
            else
            {
                return null;
            }
        }

        public string DeleteAddress(int id)
        {
            string data = "Address having id " + id + " deleted";
            comm.CommandText = "delete from Address where AddressId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return data;
        }

        public Address GetAddressById(int id)
        {
            Address address = new Address();
            comm.CommandText = "select * from Address where AddressId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int Id = Convert.ToInt32(reader["AddressId"]);
                string houseNo = reader["HouseNo"].ToString();
                string StreetName = reader["StreetName"].ToString();
                string City = reader["City"].ToString();
                int pincode = Convert.ToInt32(reader["pincode"]);
                int userId = Convert.ToInt32(reader["UserId"]);

                address = new Address(Id,houseNo,StreetName,City,pincode,userId);
            }
            conn.Close();
            return address;
        }

        public string UpdateAddress(int id, Address address)
        {
            comm.CommandText = "update Address set HouseNo = '" + address.HouseNo + "', StreetName = '" + address.StreetName + "',  City = '" + address.city + "',  pincode = '" + address.pincode + "',  userId = '" + address.Userid + "' where AddressId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            return "Address having id " + id + " is updated";
        }
    }
}