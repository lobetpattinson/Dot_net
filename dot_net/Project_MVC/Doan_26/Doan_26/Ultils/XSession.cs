using Doan_26.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_26.Ultils
{
    public class XSession
    {
        public static ShoppingCart Cart
        {
            get
            {
                var Cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
                if (Cart == null)
                {
                    Cart = new ShoppingCart();
                    HttpContext.Current.Session["Cart"] = Cart;
                }
                return Cart;
            }
        }
    }
}