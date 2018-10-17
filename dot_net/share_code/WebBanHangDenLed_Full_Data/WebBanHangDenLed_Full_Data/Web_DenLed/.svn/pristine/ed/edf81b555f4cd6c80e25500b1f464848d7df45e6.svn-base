using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        Web_DenLedDbContext db = new Web_DenLedDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Category()
        {
            var res = db.tblCategories;
            return PartialView("_MenuLeft",res);
        }
        public PartialViewResult ListSpPartial()
        {
            var list = db.tblProducts.Take(6).OrderByDescending(x => x.CreateDate).ToList();
            return PartialView(list);
        }
        public PartialViewResult ListSpHotPartial()
        {
            var list = db.tblProducts.Take(6).OrderBy(x => x.CreateDate).ToList();
            return PartialView(list);
        }
        public ActionResult Details(int id)
        {
            var res = db.tblProducts.Find(id);
            return View(res);
        }
      
    }
}