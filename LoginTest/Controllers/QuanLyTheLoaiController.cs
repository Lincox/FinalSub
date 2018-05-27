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

        public ActionResult TheLoai (int idTheLoai)
        {
            List<object> myModel = new List<object>();
            myModel.Add(db.TheLoais.ToList());
            myModel.Add(db.BaiViets.ToList());

            TheLoai type = db.TheLoais.SingleOrDefault(n => n.C_idTheLoai == idTheLoai);

            if (type == null)
            {
                return Redirect("/");
            }

            var BaiViet = db.BaiViets.Where(x => x.C_idTheLoai == idTheLoai).ToList();
            ViewBag.contentbelong = BaiViet;
            return View(BaiViet);
        }
    }
}