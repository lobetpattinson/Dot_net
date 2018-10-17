using EShop.Areas.Admin.Models;
using EShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class InventoryController : EShopController
    {
        public ActionResult ByCategory()
        {
            ViewBag.GroupBy = "Category";
            var Items = dbc.Products.GroupBy(p => p.Category).Select(g => new Inventory
            {
                Group = g.Key.NameVN,
                Count = g.Sum(item => item.Quantity),
                Value = g.Sum(item => item.Quantity * item.UnitPrice),
                MinPrice = g.Min(item => item.UnitPrice),
                MaxPrice = g.Max(item => item.UnitPrice),
                AvgPrice = g.Average(item => item.UnitPrice)
            })
            .ToList();
            return View(Items);
        }

        public ActionResult BySupplier()
        {
            ViewBag.GroupBy = "Category";
            var Items = dbc.Products.GroupBy(p => p.Supplier).Select(g => new Inventory
            {
                Group = g.Key.Name,
                Count = g.Sum(item => item.Quantity),
                Value = g.Sum(item => item.Quantity * item.UnitPrice),
                MinPrice = g.Min(item => item.UnitPrice),
                MaxPrice = g.Max(item => item.UnitPrice),
                AvgPrice = g.Average(item => item.UnitPrice)
            })
            .ToList();
            return View(Items);
        }
    }
}