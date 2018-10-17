using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_25.Models
{
    public class tblCategoryProduct
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }

        public int? CategoryID { get; set; }

        public virtual tblCategory tblCategory { get; set; }
        //public virtual tblProduct tblProducts { get; set; }
    }
}