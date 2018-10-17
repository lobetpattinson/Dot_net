using Models;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        Web_DenLedDbContext context = new Web_DenLedDbContext();
        public ActionResult ListByCat(int id)
        {
            var db = new ProductModel().ListByCat(id);
            ViewBag.T = context.tblCategories.Find(id).Name.ToString();
            return View(db);
        }
	}
}