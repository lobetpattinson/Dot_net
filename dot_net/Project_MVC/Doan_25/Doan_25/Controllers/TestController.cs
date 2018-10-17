using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_25.Controllers
{
    public class TestController : BaseController
    {
        Web_DenLedDbContext db = new Web_DenLedDbContext();
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult GetData()
        //{
        //    var model = db.tblProducts.ToList();
        //    return View(model);
        //}
        public ActionResult GetData()
        {
            return View();
        }
        public JsonResult GetData_01()
        {
            var model = db.tblProducts.Select(x => new
            {
                ProductId = x.ProductID,
                NameProduct = x.NameProduct,
                pricenew = x.PriceNews,
                Price = x.Price
            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}