using Doan_25.Model;
using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_25.Controllers
{
    public class ProductController : Controller
    {
        Web_DenLedDbContext context = new Web_DenLedDbContext();
        public ActionResult ListByCat(int id)
        {
            var db = new ProductModel().ListByCat(id);
            ViewBag.T = context.tblCategories.Find(id).Name.ToString();
            return View(db);
        }
    }
}