using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Doan_24.Models
{
    public class ManagerDbContext:DbContext
    {
        public  ManagerDbContext() : base("name=ChuoiKetNoi") { }
        public  DbSet<tblCategory> tblCategories { get; set; }
        public  DbSet<tblCategoryProduct> tblCategoryProducts { get; set; }
        public  DbSet<tblContact> tblContacts { get; set; }
        public  DbSet<Customer> tblCustomers { get; set; }
        public  DbSet<tblManufacture> tblManufactures { get; set; }
        public  DbSet<tblOrderDetail> tblOrderDetails { get; set; }
        public  DbSet<tblOrder> tblOrders { get; set; }
        public  DbSet<tblProduct_Image> tblProduct_Images { get; set; }
        public  DbSet<tblProduct> tblProducts { get; set; }
        public  DbSet<tblRole> tblRoles { get; set; }
        public  DbSet<tblUser> tblUsers { get; set; }
    }
}