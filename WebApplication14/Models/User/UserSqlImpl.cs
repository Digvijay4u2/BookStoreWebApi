using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication14.Models
{
    public class UserSqlImpl : IUserRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public UserSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public User AddUser(User user)
        {
            comm.CommandText = "insert into Users (UserName,Email,Mobile,password,CreatedAt) values ('" + user.UserName + "', '" + user.Email + "', '" + user.Mobile + "', '" + user.Mobile + "', '" + user.CreatedAt  + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public string DeleteUser(int id)
        {
            comm.CommandText = "delete from Users where UserId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();

            conn.Close();

            return "User having id " + id + " deleted";
        }

        public List<User> GetAllUser()
        {
            List<User> list = new List<User>();
            comm.CommandText = "select * from Users";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int uid = Convert.ToInt32(reader["UserId"]);
                
                string UserName = reader["UserNAme"].ToString();
                string Email = reader["Email"].ToString();
                string Mobile = reader["Mobile"].ToString();
                string password = reader["password"].ToString();
                DateTime CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);

                list.Add(new User(uid,UserName,Email,Mobile,password,CreatedAt));
            }
            conn.Close();
            return list;
        }

        public User GetUserById(int id)
        {
            User user = new User();
            comm.CommandText = "select * from Users where UserId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int uid = Convert.ToInt32(reader["UserId"]);

                string UserName = reader["UserNAme"].ToString();
                string Email = reader["Email"].ToString();
                string Mobile = reader["Mobile"].ToString();
                string password = reader["password"].ToString();
                DateTime CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);

                user = new User(uid, UserName, Email, Mobile, password, CreatedAt);
            }
            conn.Close();
            return user;
        }

        public string UpdateUser(int id, User user)
        {
            comm.CommandText = "update Users set UserName = '" + user.UserName+ "', Email = '" + user.Email + "',   Mobile = '" + user.Mobile + "',  password = '" + user.password + "',  CreatedAt = '" + user.CreatedAt +"' where UserId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            return "User having id " + id + " is updated";
        }
    }
}