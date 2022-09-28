using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrder();
        Order GetOrderByUserId(int userId);

        Order GetOrderById(int id);

        Order AddOrder(Order Order);
        
    }
}