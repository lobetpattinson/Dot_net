using Doan_26.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_26.Controllers
{
    public class HomeController : Controller
    {
        Web_DenLedDbContext db = new Web_DenLedDbContext();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult _Paginate(int PageNo = 0, int PageSize = 6)
        {
            var model = db.tblProducts.ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView (model.Skip(PageNo * PageSize).Take(PageSize));
            }
            ViewBag.PageCount = Math.Ceiling(1.0 * model.Count / PageSize);
            return PartialView(model.Skip(PageNo * PageSize).Take(PageSize));
        }
        public ActionResult _Category()
        {
            var model = db.tblCategories;
            return PartialView("_Category", model);
        }
        
        public ActionResult Detail(int Id)
        {
            var model = db.tblProducts.Find(Id);
            return View(model);
        }
    }
}