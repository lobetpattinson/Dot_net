using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_33.Controllers
{
    public class HomeController : Controller
    {
        EShopV20Entities db = new EShopV20Entities();
        public ActionResult Index()
        {
            var model = db.Products.ToList();
            return View(model);
        }
       
    }
}