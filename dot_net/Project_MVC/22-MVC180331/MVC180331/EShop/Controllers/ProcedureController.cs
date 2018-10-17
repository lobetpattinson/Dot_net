using EShop.Models;
using EShop.Models.EShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class ProcedureController : Controller
    {
        EShopDbContext db = new EShopDbContext();
        public ActionResult Index()
        {
            var model = db.Masters.ToList();
            return View(model);
        }
        public ActionResult GetData()
        {
            var model = db.Database.SqlQuery<Master>("udsLayTatCaMaster");
            return View(model);
        }
        public ActionResult Join()
        {
            var model = db.Database.SqlQuery<uds_JoinBang>("udsJoinBang");
            return View(model);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Master master)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new CategoryModel();
                    int res = model.Create(master.Id, master.Password, master.FullName, master.Email, master.Mobile);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới không thành công");
                    }
                }
                return View(master);
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Edit(int id)
        {
            var model = db.Masters.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Master master)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new CategoryModel();
                    int res = model.Edit(master.Id, master.Password, master.FullName, master.Email, master.Mobile);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update mới không thành công");
                    }
                }
                return View(master);
            }
            catch
            {
                return View();
            }
        }
       
        
        public ActionResult Delete(Master master)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new CategoryModel();
                    int res = model.Delete(master.Id);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Xoa không thành công");
                    }
                }
                return View(master);
            }
            catch
            {
                return View();
            }
        }

    }
}