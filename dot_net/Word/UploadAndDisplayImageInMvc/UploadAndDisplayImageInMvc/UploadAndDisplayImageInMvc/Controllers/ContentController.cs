using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadAndDisplayImageInMvc.Models;



namespace UploadAndDisplayImageInMvc.Controllers
{
    [RoutePrefix("Content")]
    [ValidateInput(false)]
    public class ContentController : Controller
    {
        private DBContext db = new DBContext();
       
        [Route("Index")]
        [HttpGet]
        public ActionResult Index()
        {
            var list = db.Contents.ToList();
            return View(list);

        }

        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
       
        public byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in db.Contents where temp.ID == Id select temp.Image;
            byte[] cover = q.First();
            return cover;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Content e, HttpPostedFileBase imageFile)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(imageFile.InputStream);
            imageBytes = reader.ReadBytes((int)imageFile.ContentLength);
            e.Image = imageBytes;
            db.Contents.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
         }
	}
}