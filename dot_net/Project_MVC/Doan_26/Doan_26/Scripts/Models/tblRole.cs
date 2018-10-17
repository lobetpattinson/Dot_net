using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doan_26.Models
{
    public class tblRole
    {
        [Key]
        public int RoleID { get; set; }

        [StringLength(50)]
        public string NameRole { get; set; }
    }
}