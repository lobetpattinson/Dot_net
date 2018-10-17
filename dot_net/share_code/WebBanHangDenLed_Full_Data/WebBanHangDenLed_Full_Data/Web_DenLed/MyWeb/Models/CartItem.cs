using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    [Serializable]
    public class CartItem
    {
        public tblProduct Product { set; get; }
        public int Quantity { set; get; }
    }
}