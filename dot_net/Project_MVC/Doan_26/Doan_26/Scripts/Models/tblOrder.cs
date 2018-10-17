using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Doan_26.Models
{
    public class tblOrder
    {
        [Key]
        public int OrderID { get; set; }

        public int? CustomerID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateSet { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeliveryDate { get; set; }

        public bool? Status { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        
        public virtual ICollection<tblOrderDetail> tblOrderDetails { get; set; }
    }
}