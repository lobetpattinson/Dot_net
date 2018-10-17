using EShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class AjaxRetrieveDatatableController : Controller
    {
        EShopDbContext db = new EShopDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Retrieve()
        {
            List<Master> masters = db.Masters.ToList<Master>();
            return Json(new { data=masters},JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddorEdit(int id =0)
        {
            return View(new Master());
        }
        [HttpPost]
        public ActionResult AddorEdit(Master master)
        {
            EShopDbContext db = new EShopDbContext();
            db.Masters.Add(master);
            db.SaveChanges();
            return Json(new { success = true,message = "Save successfuly",JsonRequestBehavior.AllowGet });
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var model = db.Masters.Find(id);
            return View(model);
        }
        public ActionResult Edit(Master master)
        {
            db.Entry(master).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new { success = true, message = "Update successfuly", JsonRequestBehavior.AllowGet });
        }
        public ActionResult Delete(string id)
        {
            var model = db.Masters.Find(id);
            db.Masters.Remove(model);
            db.SaveChanges();
            return Json(new { success = true, message = "Delete successfuly", JsonRequestBehavior.AllowGet });

           
        }
    }
}