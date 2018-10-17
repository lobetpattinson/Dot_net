using BotDetect.Web.Mvc;
using Models;
using Models.EF;
using MyWeb.Areas.Admin.Code;
using MyWeb.Areas.Admin.Controllers;
using MyWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MyWeb.Controllers
{
    public class UserController : BaseController
    {
        Web_DenLedDbContext db = new Web_DenLedDbContext();


        // GET: User
       [HttpGet]
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]     
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            var res = new AccountModel().Login(model.UserName,Encryptor.MD5Hash( model.Password));
            if (res == 1)
            {
                var user = db.tblCustomers.SingleOrDefault(x=>x.Account== model.UserName);
                var userSession = new UserSession();
             
                userSession.UserName = user.Account;
                userSession.UserID = user.CustomerID;
                Session.Add(CommonConstants.Customer_SESSION, userSession);
                return RedirectToAction("Index","Home");

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
            
     

        //public tblUser GetUserId(int id)
        //{
        //    var p = db.tblUsers.SingleOrDefault(x => x.UserID == id);
        //    return p;
        //}
        [HttpGet]
        public ActionResult Register()
        {
            return View();


        }


        [HttpPost]
       
        public ActionResult Register(RegisterModel model)
        {
           
                if (CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại.");

                }
                else if (CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại.");
                }
                else
                {
                    var user = new tblCustomer();
                    user.Account = model.UserName;
                   
                    user.Password = Encryptor.MD5Hash(model.Password);
                    user.Email = model.Email;
                    user.Adress = model.Address;
                    user.Phone = model.Phone;
                    var result = db.tblCustomers.Add(user);
                    db.SaveChanges();
                    SetAlert("Đăng ký thành công", "success");

                }
           
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