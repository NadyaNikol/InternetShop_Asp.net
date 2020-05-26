using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.CartFolder
{
    public class CartItem
    {
        public Good Good { get; set; }
        public int Quantity { get; set; }
    }
}