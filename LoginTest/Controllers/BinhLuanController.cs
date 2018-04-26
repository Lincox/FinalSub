using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.Models;

namespace LoginTest.Controllers
{
    public class BinhLuanController : Controller
    {
        Model1 db = new Model1();
        // GET: BinhLuan
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ThemBinhLuan()
        {
            return PartialView();
        }
        //[HttpPost]
        //public ActionResult ThemBinhLuan(BinhLuan BL, int idBaiViet)
        //{
        //    db.BinhLuans.Add(BL);
        //    db.SaveChanges();
        //    return RedirectToAction("DetailBaiViet", "NguoiViet", "C_idBaiViet");


        //}
    }
}