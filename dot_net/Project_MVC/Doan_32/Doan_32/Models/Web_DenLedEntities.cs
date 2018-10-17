using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace Doan_32.Models
{
    public class Web_DenLedEntities : DbContext
    {
        public Web_DenLedEntities()
        : base("name=ChuoiKetNoi")
        {
        }
        public DbSet<tblCategory> tblCategories { get; set; }
        public DbSet<tblCategoryProduct> tblCategoryProducts { get; set; }
        public DbSet<tblContact> tblContacts { get; set; }
        public DbSet<tblCustomer> tblCustomers { get; set; }
        public DbSet<tblManufacture> tblManufactures { get; set; }
        public DbSet<tblOrderDetail> tblOrderDetails { get; set; }
        public DbSet<tblOrder> tblOrders { get; set; }
        public DbSet<tblProduct_Images> tblProduct_Images { get; set; }
        public DbSet<tblProduct> tblProducts { get; set; }
        public DbSet<tblRole> tblRoles { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }

        public virtual ObjectResult<ListProductByCat_Result> ListProductByCat(Nullable<int> cat)
        {
            var catParameter = cat.HasValue ?
                new ObjectParameter("Cat", cat) :
                new ObjectParameter("Cat", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListProductByCat_Result>("ListProductByCat", catParameter);
        }

        public virtual ObjectResult<Nullable<bool>> Sp_Account_Login(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));

            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("Sp_Account_Login", userNameParameter, passwordParameter);
        }

        public virtual int tblCategory_Insert(string metaTitle, string name, Nullable<int> levels, Nullable<int> parentID, string sEOTitle, Nullable<int> typeID)
        {
            var metaTitleParameter = metaTitle != null ?
                new ObjectParameter("MetaTitle", metaTitle) :
                new ObjectParameter("MetaTitle", typeof(string));

            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));

            var levelsParameter = levels.HasValue ?
                new ObjectParameter("Levels", levels) :
                new ObjectParameter("Levels", typeof(int));

            var parentIDParameter = parentID.HasValue ?
                new ObjectParameter("ParentID", parentID) :
                new ObjectParameter("ParentID", typeof(int));

            var sEOTitleParameter = sEOTitle != null ?
                new ObjectParameter("SEOTitle", sEOTitle) :
                new ObjectParameter("SEOTitle", typeof(string));

            var typeIDParameter = typeID.HasValue ?
                new ObjectParameter("TypeID", typeID) :
                new ObjectParameter("TypeID", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblCategory_Insert", metaTitleParameter, nameParameter, levelsParameter, parentIDParameter, sEOTitleParameter, typeIDParameter);
        }

        public virtual ObjectResult<tblCategory_List_Result> tblCategory_List()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblCategory_List_Result>("tblCategory_List");
        }

        public virtual ObjectResult<tblProducts_List_Result> tblProducts_List()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblProducts_List_Result>("tblProducts_List");
        }
    }
}