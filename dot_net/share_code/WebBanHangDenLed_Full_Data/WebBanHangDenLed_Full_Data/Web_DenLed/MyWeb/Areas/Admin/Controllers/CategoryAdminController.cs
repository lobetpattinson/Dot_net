using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using MyWeb.Areas.Admin;
using Models;
using Models.Function;
namespace MyWeb.Areas.Admin.Controllers
{

    public class CategoryAdminController : BaseController
    {

        // GET: Admin/CategoryAdmin
        Web_DenLedDbContext db = new Web_DenLedDbContext();

        private const int pagesize = 8;
        private const string PAGE = "CURRENT_PAGE";
        public ActionResult List()
        {
            var p = new _Paging()._getPaging(pagesize, 1, new CategoryModel().ListAll());


            return View(p);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(FormCollection Cat)
        {

            var c = new tblCategory();
            c.Name = Cat["Name"];
            c.Levels = int.Parse(Cat["Levels"]);
            c.Status = bool.Parse(Cat["Status"]);
            c.CreateDate = DateTime.Now;
            c.TypeID = int.Parse(Cat["TypeID"]);
            db.tblCategories.Add(c);
            db.SaveChanges();

            SetAlert("Thêm thành công", "success");
            return RedirectToAction("List");


        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var obj = db.tblCategories.Find(id);

            return View(obj);
        }

        [HttpPost]
        public ActionResult GetDataEdit(FormCollection Cat)
        {
            var c = new tblCategory();
            //int id = int.Parse(Session["ID_UPDATE"].ToString());
            int id = int.Parse(Cat["CategoryID"].ToString());
            c.Name = Cat["Name"];
            c.Levels = int.Parse(Cat["Levels"]);
            c.Status = bool.Parse(Cat["Status"]);
            c.CreateDate = DateTime.Parse(Cat["CreateDate"]);
            c.TypeID = int.Parse(Cat["TypeID"]);

            if (new CategoryModel().EditCat(c, id))
            {
                SetAlert("Sửa thành công", "success");
                return RedirectToAction("List");
            }
            return View();
        }
        public ActionResult SendDetail(int id)
        {
            var p = new CategoryModel().GetCatId(id);
            Session["ID_UPDATE"] = p.CategoryID;
            var _p = new tblCategory();
            _p.CategoryID = p.CategoryID;
            _p.Name = p.Name;
            _p.Levels = p.Levels;
            _p.Status = p.Status;
            _p.CreateDate = p.CreateDate;
            _p.TypeID = p.TypeID;
            return Json(_p, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            if (new CategoryModel().Delete(id))
            {
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("List");

            }
            return View();
        }

        public ActionResult _paging(int _currentPage)
        {
            var p = new _Paging()._getPaging(pagesize, _currentPage, new CategoryModel().ListAll());


            return View(p);
        }

    }



}