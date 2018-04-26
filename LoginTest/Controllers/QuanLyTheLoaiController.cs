using LoginTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginTest.Controllers
{
    public class QuanLyTheLoaiController : Controller
    {
        Model1 db = new Model1();

        // GET: QuanLyTheLoai
        public ActionResult CongNghe()
        {
            var lstCN = db.BaiViets.Where(n => n.C_idTheLoai == 1).ToList();
            // Gán vào Viewbag
            ViewBag.ListCN = lstCN;

            return View();
        }

        public ActionResult HocTap()
        {
            var lstHT = db.BaiViets.Where(n => n.C_idTheLoai == 2).ToList();
            // Gán vào Viewbag
            ViewBag.ListHT = lstHT;
            return View();
        }
    }
}