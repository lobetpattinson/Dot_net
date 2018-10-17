using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Doan_31.Models
{
    [Table("tblCustomer")]
    public class tblCustomer
    {
        [Key]
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string NameCus { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "ntext")]
        public string Adress { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }

        [StringLength(40)]
        public string Account { get; set; }

        [StringLength(40)]
        public string Password { get; set; }

        
        public virtual ICollection<tblOrder> tblOrders { get; set; }
    }
}