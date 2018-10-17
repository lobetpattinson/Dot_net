using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_25.Model
{
    public class CartItem
    {
        public tblProduct Product { set; get; }
        public int Quantity { set; get; }
    }
}