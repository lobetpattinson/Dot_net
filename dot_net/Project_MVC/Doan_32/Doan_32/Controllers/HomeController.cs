using Doan_32.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_32.Controllers
{
    public class HomeController : Controller
    {
        Web_DenLedEntities db = new Web_DenLedEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            var model = db.tblProducts.ToList();
            return View(model);
        }
    }
}