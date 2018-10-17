using Doan_24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_24.Controllers
{
    public class HomeController : Controller
    {
        ManagerDbContext db = new ManagerDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            var model = db.tblProducts.ToList();
            return View(model);
        }
        public ActionResult _Category()
        {
            var model = db.tblCategories.ToList();
            return PartialView("_MenuLeft",model);
        }
        public PartialViewResult Listsp_Moi()
        {
            var model = db.tblProducts.Take(6).OrderByDescending(x => x.CreateDate).ToList();
            return PartialView(model);
        }
        public PartialViewResult ListSp_Hot()
        {
            var model = db.tblProducts.Take(6).OrderBy(x => x.CreateDate).ToList();
            return PartialView(model);
        }
    }
}