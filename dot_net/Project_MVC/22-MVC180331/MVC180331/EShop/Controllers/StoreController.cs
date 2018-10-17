using EShop.Models;
using EShop.Models.EShopModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class StoreController : Controller
    {
        EShopDbContext db = new EShopDbContext();
        public ActionResult Index()
        {
            var model = db.Masters.ToList();
            return View(model);
        }
        public ActionResult GetData()
        {
            var model = db.Database.SqlQuery<udsDanhSachNhanVien_Result>("udsDanhSachNhanVien");
            return View(model);
        }
        public ActionResult GetDataById()
        {
            var id = new SqlParameter("@Id", 1001);
            var model = db.Database.SqlQuery<udsDanhSachNhanVien_Result>("udsDanhSachNhanVienById @Id", id);
            return View(model);
        }
        public ActionResult Join()
        {
            var model = db.Database.SqlQuery<uds_DanhSachSanPham>("DanhSachSanPham");
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Master master)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var model = new CategoryModel();
                    int res = model.Create(master.Id, master.Password, master.FullName, master.Email, master.Mobile);
                    if(res > 0)

                    return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("","Them moi khong thanh cong");
                    }
                }
                return View(master);
            }
            catch
            {
                return View();
            }
        }
    }
}