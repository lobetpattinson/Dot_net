using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_36.Controllers
{
    public class HomeController : Controller
    {
        EShopV20Entities db = new EShopV20Entities();
        public ActionResult Index()
        {
            var model = db.Products.ToList();
            return View(model);
        }
        public ActionResult Store()
        {
            var model = db.Database.SqlQuery<udsDanhSachNhanVien_Result>("udsDanhSachNhanVien");
            return View(model);

        }
        pu
       
    }
}