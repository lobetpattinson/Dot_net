using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using MyWeb.Areas.Admin.Controllers;
using System.Web.Script.Serialization;

namespace MyWeb.Controllers
{
    public class LienHeController : BaseController
    {
        //
        // GET: /LienHe/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
       //public ActionResult Insert(tblContact id)
       // {
       //     var s = new LienHeModel().Insert(id);
       //     if (s>0)
       //     {
       //         SetAlert("Gửi phản hồi thành công", "success");
       //         return View();
       //     }
       //     return View();
       // }
        public JsonResult PhanHoi(string id)
        {
            var jsonCartContact = new JavaScriptSerializer().Deserialize<tblContact>(id);
            jsonCartContact.Status = false;
            jsonCartContact.DateSent = DateTime.Now;
            var s = new LienHeModel().Insert(jsonCartContact);
            if (s > 0)
            {
                SetAlert("Gửi phản hồi thành công", "success");
                
            }
            return Json(new { status = true });
        }
	}
}