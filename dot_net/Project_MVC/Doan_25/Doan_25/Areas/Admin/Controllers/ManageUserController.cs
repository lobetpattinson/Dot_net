using Doan_25.Model;
using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan_25.Areas.Admin.Controllers
{
    public class ManageUserController : Controller
    {
        //
        // GET: /Admin/ManageUser/
        Web_DenLedDbContext db = new Web_DenLedDbContext();

        private const int pagesize = 8;
        private const string PAGE = "CURRENT_PAGE";
        public ActionResult List()
        {

            var p = new _Paging()._getPagingUser(pagesize, 1, new ManageUserModel().ListAll());

            return View(p);


        }
        public ActionResult _paging(int _currentPage)
        {
            var p = new _Paging()._getPagingUser(pagesize, _currentPage, new ManageUserModel().ListAll());


            return View(p);
        }
        public ActionResult EditStatus(int id)
        {
            var p = new AccountModel().Edit(db.tblCustomers.Find(id));
            return RedirectToAction("List");
        }
    }
}