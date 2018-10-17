using Doan_25.Model;
using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_25.Controllers
{
    public class UserController : BaseController
    {
        Web_DenLedDbContext db = new Web_DenLedDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (model.UserName == "admin" && model.Password == "admin")
            {
                return RedirectToAction("Index", "Login", new { area = "Admin" });
            }
            else
            {
                var res = new AccountModel().Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (res == 1)
                {
                    var user = db.tblCustomers.SingleOrDefault(x => x.Account == model.UserName);
                    var userSession = new UserSession();

                    userSession.UserName = user.Account;
                    userSession.UserID = user.CustomerID;
                    Session.Add(CommonConstants.Customer_SESSION, userSession);
                    return RedirectToAction("Index", "Home");

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
                return View();
            }
         }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Register(RegisterModel model)
        {

                var user = new tblCustomer();
                user.Account = model.UserName;
                user.Password = Encryptor.MD5Hash(model.Password);
                user.Email = model.Email;
                user.Phone = model.Phone;
                var result = db.tblCustomers.Add(user);
                db.SaveChanges();
                SetAlert("Đăng ký thành công", "success");
                return View(model);
        }
        public bool CheckUserName(string userName)
        {
            return db.tblCustomers.Count(x => x.Account == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.tblCustomers.Count(x => x.Email == email) > 0;
        }

    }
}