using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.Models;
using System.Globalization;

namespace LoginTest.Controllers
{
    public class BaiVietController : Controller
    {
        // GET: SanPham
        //Su Dung partial view
        Model1 db = new Model1();
 
        //Tạo 2 partial view bai viet 1 và 2 để hiển thị bv theo 2 style khác nhau
        [ChildActionOnly]
        public ActionResult BaiVietStyle1Partial()
        {
            var tentheloai = from tl in db.BaiViets
                             join tl1 in db.TheLoais on tl.C_idTheLoai equals tl1.C_idTheLoai
                             where tl.C_idTheLoai == 1
                             select tl1.TheLoai1;

            ViewBag.TenTheLoai = tentheloai;

            var congnghe = from a in db.BaiViets
                            where a.C_idTheLoai == 1
                            select a;
            ViewBag.FriendRequest = congnghe;

            return PartialView();
        }

        public ActionResult BaiVietStyle2Partial()
        {
            ViewBag.C_idTheLoai = new SelectList(db.TheLoais, "C_idTheLoai", "TheLoai1");
            return PartialView();
        }

        public ActionResult BaiVietStyle3Partial()
        {
            return PartialView();
        }

        public ActionResult PartialForHomeWriter()
        {
            return PartialView();
        }
        public ActionResult CommentStyle1Partial()
        {
            return PartialView();
        }
        public ActionResult CommentStyle2Partial()
        {
            return PartialView();
        }

        public ActionResult Index()
        {
            return View();
        }


        
    }
}