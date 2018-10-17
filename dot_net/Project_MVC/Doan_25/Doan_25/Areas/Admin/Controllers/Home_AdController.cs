using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_25.Areas.Admin.Controllers
{
    public class Home_AdController : Controller
    {
        // GET: Admin/Home_Ad
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Account()
        {
            ViewBag.User = "Trong".ToString();
            return PartialView();
        }
        public PartialViewResult UserInfo()
        {
            //ViewBag.A = Session[CommonConstants.USER_SESSION];
            return PartialView();
        }
    }
}