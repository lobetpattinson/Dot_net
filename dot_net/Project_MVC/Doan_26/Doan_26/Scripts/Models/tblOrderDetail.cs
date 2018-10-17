using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_26.Models
{
    public class tblOrderDetail
    {
        public int ID { get; set; }

        public int? OrderID { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public virtual tblOrder tblOrder { get; set; }
    }
}