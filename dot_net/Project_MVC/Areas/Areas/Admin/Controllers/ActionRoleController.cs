using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class ActionRoleController : EShopController
    {
        public ActionResult Index()
        {
            ViewBag.RoleId = new SelectList(dbc.Roles, "Id", "Name");
            ViewBag.WebActions = dbc.WebActions.ToList();
            return View();
        }

        public ActionResult AddOrDelete(ActionRole model)
        {
            var Message = "";
            try
            {
                var entity = dbc.ActionRoles
                    .Single(mr => mr.RoleId == model.RoleId && mr.WebActionId == model.WebActionId);
                dbc.ActionRoles.Remove(entity);
                Message = "Xóa vai trò thành công!";
            }
            catch
            {
                dbc.ActionRoles.Add(model);
                Message = "Thêm vai trò thành công!";
            }
            dbc.SaveChanges();
            return Content(Message);
        }

        public ActionResult GetWebActionIds(String Id)
        {
            var data = dbc.ActionRoles
                .Where(mr => mr.RoleId == Id)
                .Select(mr => mr.WebActionId)
                .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}