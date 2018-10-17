using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_32.Models
{
    public class tblOrder
    {
        public int OrderID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<System.DateTime> DateSet { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<bool> Status { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }
        public virtual ICollection<tblOrderDetail> tblOrderDetails { get; set; }
    }
}