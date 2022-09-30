using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public interface IAddressRepository
    {
        Address GetAddressById(int id);
      Address AddAddress(Address address);
        string DeleteAddress(int id);
        string UpdateAddress(int id, Address address);
    }
}