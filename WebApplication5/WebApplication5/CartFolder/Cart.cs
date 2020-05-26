using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.CartFolder
{
    public class Cart
    {
        private List<CartItem> cartItems = new List<CartItem>();
        public IEnumerable<CartItem> CartItems => cartItems;

        public void AddItem(Good good, int quantity)
        {
            CartItem cartItem = cartItems.FirstOrDefault(g => g.Good.ID == good.ID);

            if (cartItem != null)
                cartItem.Quantity += quantity;
            else
                cartItems.Add(new CartItem { Good = good, Quantity = quantity });

        }

        public void RemoveItem(Good good)
        {
            cartItems.RemoveAll(c => c.Good.ID == good.ID);
        }

        public double CalculateTotalValue()
        {
            return cartItems.Sum(c => c.Good.Price * c.Quantity);
        }

        public void Clear()
        {
            cartItems.Clear();
        }

    }
}