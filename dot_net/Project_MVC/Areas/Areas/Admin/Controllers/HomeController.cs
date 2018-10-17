using EShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class HomeController : EShopController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Id, String Password)
        {
            var master = dbc.Masters.Find(Id);
            if (master == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập!");
            }
            else if (master.Password != Password)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập");
            }
            else
            {
                XSession.Master = master;
                ModelState.AddModelError("", "Đăng nhập thành công!");
                if (XSession.ReturnUrl != null)
                {
                    return Redirect(XSession.ReturnUrl);
                }
            }
            return View();
        }
    }
}