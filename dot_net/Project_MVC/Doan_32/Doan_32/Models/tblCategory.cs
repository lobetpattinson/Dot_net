using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_32.Models
{
    public class tblCategory
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Levels { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> TypeID { get; set; }

        public virtual ICollection<tblCategoryProduct> tblCategoryProducts { get; set; }
    }
}