using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class MasterRoleController : EShopController
    {
        public ActionResult Index()
        {
            ViewBag.MasterId = new SelectList(dbc.Masters, "Id", "FullName");
            ViewBag.Roles = dbc.Roles.ToList();
            return View();
        }

        public ActionResult AddOrDelete(MasterRole model)
        {
            var Message = "";
            try
            {
                var entity = dbc.MasterRoles
                    .Single(mr => mr.RoleId == model.RoleId && mr.MasterId == model.MasterId);
                dbc.MasterRoles.Remove(entity);
                Message = "Xóa vai trò thành công!";
            }
            catch
            {
                dbc.MasterRoles.Add(model);
                Message = "Thêm vai trò thành công!";
            }
            dbc.SaveChanges();
            return Content(Message);
        }

        public ActionResult GetRoleIds(String Id)
        {
            var data = dbc.MasterRoles
                .Where(mr => mr.MasterId == Id)
                .Select(mr => mr.RoleId)
                .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}