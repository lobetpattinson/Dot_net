﻿using ActionFilter.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFilter.Controllers
{
    
    public class HomeController : Controller
    {
        [LogFilter]
        public ActionResult Index()
        {
            Log.log("Index()");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}