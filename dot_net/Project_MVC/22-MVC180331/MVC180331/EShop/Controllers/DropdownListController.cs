using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class DropdownListController : Controller
    {
        //https://sethphat.com/sp-372/razor-view-asp-net-mvc-dropdownlist
        EShopDbContext db = new EShopDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            List<Category> cate = db.Categories.ToList();
            //< option value = "1001" > Laptops </ option >
            SelectList catelist = new SelectList(cate, "ID", "Name");
            ViewBag.CategoryList = catelist;
            return View();
        }
        public ActionResult GetDataforeach()
        {
            var model = db.Categories.ToList();
            return View(model);
        }

    }
}