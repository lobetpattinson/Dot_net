using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class CustomerController : EShopController
    {
        public ActionResult Index()
        {
            var model = new Customer();
            ViewBag.Items = dbc.Customers.ToList();
            return View(model);
        }

        public ActionResult Edit(String Id)
        {
            var model = dbc.Customers.Find(Id);
            ViewBag.Items = dbc.Customers.ToList();
            return View("Index", model);
        }

        public ActionResult Insert(Customer entity)
        {
            var file = Request.Files["UpPhoto"];
            if (file.ContentLength > 0)
            {
                entity.Photo = file.FileName;
                file.SaveAs(Server.MapPath("~/Images/Customers/"+entity.Photo));
            }
            else
            {
                entity.Photo = "Customer.png";
            }
            try
            {
                dbc.Customers.Add(entity);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(Customer entity)
        {
            var file = Request.Files["UpPhoto"];
            if (file.ContentLength > 0)
            {
                entity.Photo = file.FileName;
                file.SaveAs(Server.MapPath("~/Images/Customers/" + entity.Photo));
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
                var entity = dbc.Customers.Find(Id);
                dbc.Customers.Remove(entity);
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