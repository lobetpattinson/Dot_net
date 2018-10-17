using Models;
using Models.EF;
using MyWeb.Areas.Admin.Code;
using MyWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.LoginModel model)
        {
            var res = new LoginModel().Login(model.UserName, Encryptor.MD5Hash(model.Password));
            if (res ==1)
            {
                //SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                var user=new  AccountModel().GetById(model.UserName);
                var userSession =new  UserSession();
                userSession.UserName=user.Account;
                userSession.UserID=user.UserID;
                Session.Add(CommonConstants.USER_SESSION, userSession);
                return RedirectToAction("Index", "ProductAdmin");
            }else if (res ==0)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại");
            }
            else if (res == -1)
            {
                ModelState.AddModelError("", "Tài khoản đang bị khóa");
            }
            else if(res ==-2)
            {
                ModelState.AddModelError("", "Mật khẩu không đúng");
            }
            

            return View(model);
        }
        
	}
}