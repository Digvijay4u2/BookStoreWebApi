using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class User
    {
        public int UserId { get;set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string password { get; set; }
        public DateTime CreatedAt { get; set; }


        public User()
        {

        }

        public User(int uId, string uNAme,string email,string mobile,string password,DateTime createdat)
        {
            this.UserId = uId;
            this.UserName = uNAme;
            this.Email = email;
            this.Mobile = mobile;
            this.password = password;
            this.CreatedAt = createdat;
        }

    }
}