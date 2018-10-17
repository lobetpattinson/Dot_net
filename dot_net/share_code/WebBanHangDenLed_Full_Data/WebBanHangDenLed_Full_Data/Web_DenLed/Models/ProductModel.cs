using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class ProductModel
    {
       Web_DenLedDbContext db = null;
       public ProductModel()
       {
           db = new Web_DenLedDbContext();
       }
       public List<tblProduct> ListAll()
       {
           var res= db.tblProducts.ToList();
           return res;
       }
       public List<tblProduct> ListByCat(int id)
       {
           var res = db.Database.SqlQuery<tblProduct>("ListProductByCat @Cat", new SqlParameter("@Cat", id)).ToList();
           return res;
       }
       public tblProduct getById(int id)
       {
           var p=db.tblProducts.SingleOrDefault(x=>x.ProductID==id);
           return p;
       }
       public bool EditProduct(tblProduct p,int id)
       {
           var _p = getById(id);
            _p.NameProduct=p.NameProduct;
            _p.Content = p.Content;
           
            _p.DienAp = p.DienAp;
            _p.DoKin = p.DoKin;
           _p.GocMo = p.GocMo;
            _p.HeSoCongSuat = p.HeSoCongSuat;
            _p.HeSoCRI = p.HeSoCRI;
            _p.ImagesMain = p.ImagesMain;
            _p.LedChip = p.LedChip;
            _p.ManufacturesID =p.ManufacturesID;
            _p.MetaTitle = p.MetaTitle;
            _p.NhietDoLamViec = p.NhietDoLamViec;
            _p.NhietDoMau = p.NhietDoMau;
         
            _p.Price = p.Price;
            _p.PriceNews = p.PriceNews;
            _p.ProductID = id;
            _p.QuangThong = p.QuangThong;
            _p.Quantity =p.Quantity;
            _p.Status = p.Status;
            db.SaveChanges();
            return true;
       }
       public bool Delete(int id)
       {
           var model = db.tblProducts.SingleOrDefault(x => x.ProductID == id);
           db.tblProducts.Remove(model);
           db.SaveChanges();
           return true;
       }
       public int Create(tblProduct p)
       {
           var c = db.tblProducts.Add(p);
           db.SaveChanges();
           return c.ProductID;
       }
       private string[] imageExt = { ".jpg", ".png", ".jpeg", ".gif", ".JPG", ".PNG", ".JPEG", ".GIF" };
       public bool isImage(string _ext)
       {
           foreach (var i in imageExt)
           {
               if (i.Equals(_ext)) { return true; }
           }
           return false;
       }
       public string getImage(int id)
       {
           string _image ="";
           var p = getById(id);
           _image = p.ImagesMain;
          
           return _image;
       }
    }
}
