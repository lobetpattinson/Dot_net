using EShop.Models;
using EShop.Models.EShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class CheckoxController : Controller
    {
        EShopDbContext db = new EShopDbContext();
        public ActionResult Index()
        {
            var model = db.Masters.ToList();
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
    }
}