using Doan_24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_24.Controllers
{
    public class ProductController : Controller
    {
        ManagerDbContext context = new ManagerDbContext();
        public ActionResult ListByCat(int Id)
        {
            var db = new tblProductModel().ListByCat(Id);
            ViewBag.T = context.tblCategories.Find(Id).Name.ToString();
            return View(db);
           
        }
    }
}