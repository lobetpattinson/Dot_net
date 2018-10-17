using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class ProductController : EShopController
    {
        public ActionResult Index()
        {
            var model = new Product();
            ViewBag.Items = dbc.Products.ToList();
            ViewBag.CategoryId = new SelectList(dbc.Categories, "Id", "NameVN");
            ViewBag.SupplierId = new SelectList(dbc.Suppliers, "Id", "Name");
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            var model = dbc.Products.Find(Id);
            ViewBag.Items = dbc.Products.ToList();
            ViewBag.CategoryId = new SelectList(dbc.Categories, "Id", "NameVN", model.CategoryId);
            ViewBag.SupplierId = new SelectList(dbc.Suppliers, "Id", "Name", model.SupplierId);
            return View("Index", model);
        }
        [ValidateInput(false)]
        public ActionResult Insert(Product entity)
        {
            var file = Request.Files["UpImage"];
            if (file.ContentLength > 0)
            {
                entity.Image = file.FileName;
                file.SaveAs(Server.MapPath("~/Images/Products/"+entity.Image));
            }
            else
            {
                entity.Image = "Product.png";
            }
            try
            {
                dbc.Products.Add(entity);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
            }
            return RedirectToAction("Index");
        }
        [ValidateInput(false)]
        public ActionResult Update(Product entity)
        {
            var file = Request.Files["UpImage"];
            if (file.ContentLength > 0)
            {
                entity.Image = file.FileName;
                file.SaveAs(Server.MapPath("~/Images/Products/" + entity.Image));
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

        public ActionResult Delete(int Id)
        {
            try
            {
                var entity = dbc.Products.Find(Id);
                dbc.Products.Remove(entity);
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