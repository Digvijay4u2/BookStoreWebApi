using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication14.Models
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserById(int id);
        User AddUser(User user);
        string DeleteUser(int id);
        string UpdateUser(int id, User user);
    }
}