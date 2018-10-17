using EShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class EntityController : Controller
    {
        EShopDbContext db = new EShopDbContext();
        public ActionResult Index()
        {
            var model = db.Masters.ToList();
            return View(model);
            
        }
        public ActionResult GetData()
        {
            var model = db.Products.ToList();
            return View(model);
        }
        public ActionResult GetDataMaster()
        {
            var model = db.Masters.ToList();
            return View(model);
        }
        public ActionResult DeleteMaster(string id)
        {
            var master = db.Masters.Find(id);
            db.Masters.Remove(master);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            var master = db.Masters.Find(id);
            return View(master);
        }
        [HttpPost]
        public ActionResult Edit(Master model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Master master)
        {
            db.Masters.Add(master);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}