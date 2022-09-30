using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string HouseNo { get; set; }
        public string StreetName { get; set; }
        public string city { get; set; }
        public int pincode { get; set; }
        public int Userid { get; set; }

        public Address()
        { }

        public Address(int addressId,string houseNo,string streetName,string city,int pincode,int userId)
        {
            this.AddressId = addressId;
            this.HouseNo = houseNo;
            this.StreetName = streetName;
            this.city = city;
            this.pincode = pincode;
            this.Userid = userId;
        }

    }
}