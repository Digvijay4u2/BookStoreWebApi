using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models.Cart
{
    public interface ICartRepository
    {

        List<Cart> GetAllCart();
        Cart AddCart(Cart cart);
        string DeleteCart(int id);
        string UpdateCart(int id, Cart cart);
    }
}