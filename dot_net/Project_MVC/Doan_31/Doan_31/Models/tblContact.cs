using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Doan_31.Models
{
    public class tblContact
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateSent { get; set; }

        public bool? Status { get; set; }
    }
}