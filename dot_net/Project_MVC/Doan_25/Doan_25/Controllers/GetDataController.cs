using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_25.Controllers
{
    public class GetDataController : Controller
    {
        Web_DenLedDbContext db = new Web_DenLedDbContext();
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult GetAllEmployee()
        //{
        //    var model = db.tblProducts.ToList();
        //    return View(model);
        //}
        public JsonResult GetAllEmployee()
        {

            var model = db.tblProducts.Select(x => new
            {
                ProductID = x.ProductID,
                NameProduct = x.NameProduct,
                // Price = x.Price,
                //PriceNews = x.PriceNews
            }).ToList();
            return Json (model,JsonRequestBehavior.AllowGet);
        }
    }
}