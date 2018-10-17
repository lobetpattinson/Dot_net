﻿using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Filters
{
    public class AdministrateAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            var uri = ctx.HttpContext.Request.Url.AbsoluteUri;
            if(!uri.Contains("/Admin/") || uri.Contains("/Admin/Home")){
                return;
            }

            var Master = HttpContext.Current.Session["Master"] as Master;
            if (Master == null)
            {
                HttpContext.Current.Session["ReturnUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                ctx.Result = new RedirectResult("/Admin/Home/Login?Reason=Chua dang nhap");
                return;
            }

            var action = (ctx.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + ctx.ActionDescriptor.ActionName).ToLower();
            using (var dbc = new EShopDbContext())
            {
                if (!dbc.WebActions.Any(wa => wa.Name == action))
                {
                    return;
                }

                var RoleIds = dbc.MasterRoles
                    .Where(mr=>mr.MasterId==Master.Id)
                    .Select(mr=>mr.RoleId);

                if(dbc.ActionRoles
                    .Any(ar=>ar.WebAction.Name == action && RoleIds.Contains(ar.RoleId)))
                {
                    return;
                }

                HttpContext.Current.Session["ReturnUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                ctx.Result = new RedirectResult("/Admin/Home/Login?Reason=Chua cap quyen");
            }
        }
    }
}