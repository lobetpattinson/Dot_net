using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Doan_31.Models
{
    public class Web_DenLedDbContext:DbContext
    {
        public Web_DenLedDbContext()
           : base("name=ChuoiKetNoi")
        {
        }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblCategoryProduct> tblCategoryProducts { get; set; }
        public virtual DbSet<tblContact> tblContacts { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers{ get; set; }
        public virtual DbSet<tblManufacture> tblManufactures { get; set; }
        public virtual DbSet<tblOrderDetail> tblOrderDetails { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        public virtual DbSet<tblProduct_Images> tblProduct_Images { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    }
}