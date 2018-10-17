using Doan_26.Ultils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_26.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
       
        public ActionResult Add(int Id)
        {
            XSession.Cart.Add(Id);
            var data = new
            {
                Count = XSession.Cart.Count,
                Amount = String.Format("{0:#,###.#0}", XSession.Cart.Amount)
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}