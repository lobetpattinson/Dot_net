using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Doan_24.Models
{
    public class tblCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? Levels { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? TypeID { get; set; }
        public virtual ICollection<tblCategoryProduct> tblCategoryProducts { get; set; }

    }
}