﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Admin/Base/
        protected void SetAlert(string mes,string type)
        {
            TempData["AlertMes"] = mes;
            if (type=="success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if(type=="warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
	}
}