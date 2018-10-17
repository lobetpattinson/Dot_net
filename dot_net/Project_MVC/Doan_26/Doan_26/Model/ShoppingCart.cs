using Doan_26.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_26.Model
{
    public class ShoppingCart
    {
        public List<tblProduct> Items = new List<tblProduct>();
        public void Add(int Id)
        {
            try
            {
                var Item = Items.Single(p => p.ProductID == Id);
                Item.Quantity++;
            }
            catch
            {
                using (var dbc = new Web_DenLedDbContext())
                {
                    var Item = dbc.tblProducts.Find(Id);
                    Item.Quantity = 1;
                    Items.Add(Item);
                }
            }
        }
        public double Amount
        {
            
            get
            {
                var d = Items.Sum(p => p.Quantity * p.PriceNews);
                double pi = (double)d;
                return pi;
            }
        }
        public int Count
        {
            get
            {
                var i = Items.Sum(p => p.Quantity);
                int k = (int)i;
                return k;
            }
        }
    }
}