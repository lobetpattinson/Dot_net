using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class SupplierController : EShopController
    {
        public ActionResult Index()
        {
            var model = new Supplier();
            ViewBag.Items = dbc.Suppliers.ToList();
            return View(model);
        }

        public ActionResult Edit(String Id)
        {
            var model = dbc.Suppliers.Find(Id);
            ViewBag.Items = dbc.Suppliers.ToList();
            return View("Index", model);
        }

        public ActionResult Insert(Supplier entity)
        {
            var file = Request.Files["UpLogo"];
            if (file.ContentLength > 0)
            {
                entity.Logo = file.FileName;
                file.SaveAs(Server.MapPath("~/Images/Suppliers/"+entity.Logo));
            }
            else
            {
                entity.Logo = "Supplier.png";
            }
            try
            {
                dbc.Suppliers.Add(entity);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(Supplier entity)
        {
            var file = Request.Files["UpLogo"];
            if (file.ContentLength > 0)
            {
                entity.Logo = file.FileName;
                file.SaveAs(Server.MapPath("~/Images/Suppliers/" + entity.Logo));
            }
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

        public ActionResult Delete(String Id)
        {
            try
            {
                var entity = dbc.Suppliers.Find(Id);
                dbc.Suppliers.Remove(entity);
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