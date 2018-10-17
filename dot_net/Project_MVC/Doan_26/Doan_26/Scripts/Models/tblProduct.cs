using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Doan_26.Models
{
    public class tblProduct
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName = "ntext")]
        public string MetaTitle { get; set; }

        [Column(TypeName = "ntext")]
        public string NameProduct { get; set; }

        public decimal? Price { get; set; }

        public decimal? PriceNews { get; set; }

        public int? ManufacturesID { get; set; }

        [StringLength(100)]
        public string ImagesMain { get; set; }

        [StringLength(10)]
        public string DienAp { get; set; }

        [StringLength(50)]
        public string LedChip { get; set; }

        public int? Quantity { get; set; }

        [StringLength(50)]
        public string TuoiTho { get; set; }

        [StringLength(10)]
        public string QuangThong { get; set; }

        [StringLength(10)]
        public string HeSoCRI { get; set; }

        [StringLength(10)]
        public string NhietDoMau { get; set; }

        [StringLength(10)]
        public string GocMo { get; set; }

        [StringLength(10)]
        public string DoKin { get; set; }

        [Column(TypeName = "ntext")]
        public string NhietDoLamViec { get; set; }

        [StringLength(10)]
        public string HeSoCongSuat { get; set; }

        [StringLength(10)]
        public string VatLieu { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public int? Warranty { get; set; }

        public int? UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }
    }
}