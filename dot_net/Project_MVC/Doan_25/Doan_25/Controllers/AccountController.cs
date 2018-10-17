using Doan_25.Models;
using Doan_25.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_25.Controllers
{
    public class AccountController : Controller
    {
        Web_DenLedDbContext db = new Web_DenLedDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        
    }
}