using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doan_26.Models
{
    public class tblProduct_Images
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(100)]
        public string Images { get; set; }

        [StringLength(100)]
        public string Images_Thum { get; set; }
    }
}