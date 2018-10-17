
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models
{
    public class CategoryModel
    {
        Web_DenLedDbContext db = new Web_DenLedDbContext();

        public List<tblCategory> ListAll()
        {
            var res = db.tblCategories.ToList();
            return res;
        }

        public tblCategory GetCatId(int id)
        {
            var p = db.tblCategories.SingleOrDefault(x => x.CategoryID == id);
            return p;
        }
        public bool EditCat(tblCategory p, int ID)
        {
            var a = GetCatId(ID);
            a.Name = p.Name;
            a.Levels = p.Levels;
            a.Status = p.Status;
            a.CreateDate = p.CreateDate;
            a.TypeID = p.TypeID;
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var model = db.tblCategories.SingleOrDefault(x => x.CategoryID == id);
            db.tblCategories.Remove(model);
            db.SaveChanges();
            return true;
        }
        public int Create(tblCategoryProduct cat)
        {
            var c = db.tblCategoryProducts.Add(cat);
            db.SaveChanges();
            return c.ID;
        }
    }
}