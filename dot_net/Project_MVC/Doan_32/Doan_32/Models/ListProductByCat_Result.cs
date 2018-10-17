using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_32.Models
{
    public class ListProductByCat_Result
    {
        public int ProductID { get; set; }
        public string MetaTitle { get; set; }
        public string NameProduct { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> PriceNews { get; set; }
        public Nullable<int> ManufacturesID { get; set; }
        public string ImagesMain { get; set; }
        public string DienAp { get; set; }
        public string LedChip { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string TuoiTho { get; set; }
        public string QuangThong { get; set; }
        public string HeSoCRI { get; set; }
        public string NhietDoMau { get; set; }
        public string GocMo { get; set; }
        public string DoKin { get; set; }
        public string NhietDoLamViec { get; set; }
        public string HeSoCongSuat { get; set; }
        public string VatLieu { get; set; }
        public string Content { get; set; }
        public Nullable<int> Warranty { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> ProductID1 { get; set; }
        public Nullable<int> CategoryID { get; set; }
    }
}