using Doan_25.Controllers;
using Doan_25.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_25.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var res = new LoginModel().Login(model.UserName, Encryptor.MD5Hash(model.Password));
            if (res == 1)
            {
                //SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                var user = new AccountModel().GetById(model.UserName);
                var userSession = new UserSession();
                userSession.UserName = user.Account;
                userSession.UserID = user.UserID;
                Session.Add(CommonConstants.USER_SESSION, userSession);
                return RedirectToAction("Index", "ProductAdmin");
            }
            else if (res == 0)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại");
            }
            else if (res == -1)
            {
                ModelState.AddModelError("", "Tài khoản đang bị khóa");
            }
            else if (res == -2)
            {
                ModelState.AddModelError("", "Mật khẩu không đúng");
            }


            return View(model);
        }
    }
}