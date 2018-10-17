using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_25.Controllers
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
            var res = db.tblCategories.ToList();
            return PartialView("_Menuleft", res);
        }
        public ActionResult List(int PageNo=0,int PageSize =6)
        {
            var model = db.tblProducts.ToList();
            if(Request.IsAjaxRequest())
            {
                return PartialView("_List", model.Skip(PageNo * PageSize).Take(PageSize));
            }
            ViewBag.PageCount = Math.Ceiling(1.0 * model.Count / PageSize);
            return PartialView(model.Skip(PageNo * PageSize).Take(PageSize));
        }
        public ActionResult Details(int id)
        {
            var res = db.tblProducts.Find(id);
            return View(res);
        }
    }
}