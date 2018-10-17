using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_32.Models
{
    public class tblProduct_Images
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string Images { get; set; }
        public string Images_Thum { get; set; }
    }
}