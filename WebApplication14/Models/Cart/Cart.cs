using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models.Cart
{
    public class Cart
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }

        public Cart()
        {

        }

        public Cart(int cartId,int bookId,int quantity,bool status)
        {
            this.CartId = cartId;
            this.BookId = bookId;
            this.Quantity = quantity;
            this.Status = status;
        }
    }
}