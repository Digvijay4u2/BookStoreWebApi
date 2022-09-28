using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public bool OrderStatus { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int BookId { get; set; }

        public Order()
        {

        }

        public Order(int oderId, bool orderStatus, int userId, DateTime date, int bookId)
        {
            this.OrderId = oderId;
            this.OrderStatus = orderStatus;
            this.UserId = userId;
            this.Date = date;
            this.BookId = bookId;
        }

    }
}