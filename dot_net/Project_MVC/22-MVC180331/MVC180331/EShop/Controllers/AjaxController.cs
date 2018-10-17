using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class AjaxController : Controller
    {
        EShopDbContext db = new EShopDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            return View();
        }
        public JsonResult GetAllData()
        {
            var model = db.Masters.Select(x => new
            {
                id = x.Id,
                pass = x.Password,
                Full = x.FullName,
                email = x.Email,
                mobile = x.Mobile
            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}