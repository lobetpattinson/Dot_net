using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_32.Models
{
    public class tblCategoryProduct
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> CategoryID { get; set; }

        public virtual tblCategory tblCategory { get; set; }
    }
}