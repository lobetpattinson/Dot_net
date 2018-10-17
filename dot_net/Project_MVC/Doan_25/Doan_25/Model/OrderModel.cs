using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_25.Model
{
    public class OrderModel
    {
        Web_DenLedDbContext db = null;
        public OrderModel() { db = new Web_DenLedDbContext(); }
        public int Add(tblOrder tb)
        {
            var c = db.tblOrders.Add(tb);

            db.SaveChanges();
            return c.OrderID;
        }
    }
}