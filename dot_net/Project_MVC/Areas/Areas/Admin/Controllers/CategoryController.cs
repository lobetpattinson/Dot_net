using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class CategoryController : EShopController
    {
        public ActionResult Index()
        {
            var model = new Category();
            ViewBag.Items = dbc.Categories.ToList();
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            var model = dbc.Categories.Find(Id);
            ViewBag.Items = dbc.Categories.ToList();
            return View("Index", model);
        }

        public ActionResult Insert(Category entity)
        {
            try
            {
                dbc.Categories.Add(entity);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(Category entity)
        {
            try
            {
                dbc.Entry(entity).State = System.Data.EntityState.Modified;
                dbc.SaveChanges();
                TempData["Message"] = "Cập nhật thành công!";
            }
            catch
            {
                TempData["Message"] = "Cập nhật thất bại!";
            }
            return RedirectToAction("Edit", new { entity.Id });
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                var entity = dbc.Categories.Find(Id);
                dbc.Categories.Remove(entity);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
            }
            return RedirectToAction("Index");
        }
    }
}