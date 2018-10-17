using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_32.Models
{
    public class tblCustomer
    {
        public int CustomerID { get; set; }
        public string NameCus { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Sex { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        public virtual ICollection<tblOrder> tblOrders { get; set; }
    }
}
