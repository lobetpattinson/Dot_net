using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class OrderController : EShopController
    {
        public ActionResult Index()
        {
            var model = new Order();
            ViewBag.Items = dbc.Orders.ToList();
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            var model = dbc.Orders.Find(Id);
            ViewBag.Items = dbc.Orders.ToList();
            return View("Index", model);
        }

        public ActionResult Insert(Order entity)
        {
            try
            {
                dbc.Orders.Add(entity);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(Order entity)
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
                var entity = dbc.Orders.Find(Id);
                dbc.Orders.Remove(entity);
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