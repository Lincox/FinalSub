using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.Models;

namespace LoginTest.Controllers
{
    public class NguoiVietController : Controller
    {
        // GET: NguoiViet
        Model1 db = new Model1();

        public object CommonConstants { get; private set; }

        public ActionResult Index(int idBV)
        {
            var BaiViet = db.BaiViets.Where(x => x.C_idBaiViet == idBV).SingleOrDefault();
            var guser = db.BaiViets.ToList();
            return View(guser);
            //return RedirectToAction("HomeNguoiViet");
        }

        //HomeNguoiViet
        public ActionResult HomeNguoiViet(string idUser)
        {
            List<object> myModel = new List<object>();
            myModel.Add(db.Users.ToList());
            myModel.Add(db.BaiViets.ToList());

            User guser = db.Users.SingleOrDefault(n => n.C_idUser == idUser);

            //if (guser.Quyen == "3")
            //var guser = db.Users.Where(x => x.Quyen == "4").SingleOrDefault();

            if (guser == null)
            {
                return Redirect("/");
            }

            if (guser.Quyen == 4 || guser.Quyen == 5)
            {
                var BaiViet = db.BaiViets.Where(x => x.C_idUserDang == idUser).ToList();
                ViewBag.contentbelong = BaiViet;
                return View(BaiViet);
            }
           
            return Redirect("/");
        }

        public ActionResult DetailBaiViet (int idBaiViet,int? idBinhLuan)
        {
            var model = from a in db.BaiViets
                        join b in db.BinhLuans
                        on a.C_idBaiViet equals b.C_idBaiViet
                        where a.C_idBaiViet == idBaiViet
                        select new BaiViet_BinhLuanViewModels()
                        {
                            C_idBaiViet = a.C_idBaiViet,
                            TieuDe = a.TieuDe,
                            AnhBia = a.AnhBia,
                            NgayDang = a.NgayDang,
                            NgayChinhSua = a.NgayChinhSua,
                            NoiDung = a.NoiDung,
                            SoLanXem = a.SoLanXem,
                            TrangThaiBaiViet = a.TrangThaiBaiViet,
                            TomTatNoiDung = a.TomTatNoiDung,
                            ThoiDiemBinhLuan = b.ThoiDiemBinhLuan,
                            NoiDungBL = b.NoiDung,
                            CapBac = b.CapBac,
                            C_idBinhLuanGoc = b.C_idBinhLuanGoc

                        };
            var detail1 = db.BaiViets.SingleOrDefault(x => x.C_idBaiViet == idBaiViet);
            Session["DetailBV"] = detail1.C_idBaiViet;
            var Detail = db.BaiViets.Where(x => x.C_idBaiViet == idBaiViet).ToList();
            return View(Detail);
        }

        public ActionResult CommentStyle1Partial(int idBaiViet)
        {
            var BaiViet = db.BinhLuans.Where(x => x.C_idBaiViet == idBaiViet && x.CapBac == 1).ToList();
            // var BaiViet1 = db.BinhLuans.Where(x => x.C_idBaiViet == idBaiViet && x.CapBac == 1).SingleOrDefault();

            return PartialView(BaiViet);
        }

        public ActionResult CommentStyle2Partial(int idBinhLuan)
        {
            //var Comment1 = db.BinhLuans.SingleOrDefault(x => x.C_idBinhLuan == idBinhLuan);
            //Session["DetailCM"] = Comment1.C_idBinhLuan.ToString();
            //Session["DetailCM"] = idBinhLuan.ToString();
            var Comment = db.BinhLuans.Where(x => x.CapBac == 2 && x.C_idBinhLuanGoc == idBinhLuan).ToList();
            //Session["DetailCM1"] = BaiViet.ToString();
            //for (int i=0; i < BaiViet.Count; i++)
            //if (BaiViet.Count != 0)
            //{
            //    foreach (var rep in BaiViet)
            //    {

            //        Session["DetailCM"] = idBinhLuan.ToString();
            //    }

            //}
            //{

            //}
            return PartialView(Comment);
        }


        [HttpGet]
        public ActionResult ThemBinhLuan()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ThemBinhLuan(BinhLuan BL)
        {
            
            db.Entry(BL).State = System.Data.Entity.EntityState.Modified;
            BL.C_idBaiViet = (int)Session["DetailBV"];
            BL.C_idUserDoc = Session["QuyenID"].ToString();
            BL.ThoiDiemBinhLuan = DateTime.Now;
            BL.CapBac = 1;
            BL.C_idBinhLuanGoc = null;
            //Session["CommentCap1"] = BL.C_idBinhLuan.ToString();
            db.BinhLuans.Add(BL);
            db.SaveChanges();
            return RedirectToAction("DetailBaiViet", "NguoiViet", new { @idBaiViet = Session["DetailBV"] });
        }

        [HttpGet]
        public ActionResult ThemBinhLuanCap2(int idBinhLuan1)
        {
            BinhLuan BL1 = new BinhLuan { C_idBinhLuanGoc = idBinhLuan1 };

            return PartialView(BL1);
        }
        [HttpPost]
        public ActionResult ThemBinhLuanCap2(BinhLuan BL1)
        {
            // BinhLuan BL1 = new BinhLuan();
            //BinhLuan BL1;2
            //Session["DetailCM1"] = idBinhLuan.ToString();
            // var x1 = db.BinhLuans.Where(x => x.C_idBinhLuan == idBinhLuan).FirstOrDefault();
            // BinhLuan BL12 = db.BinhLuans.SingleOrDefault(n => n.C_idBinhLuan == idBinhLuan1);
            //db.Entry(BL1).State = System.Data.Entity.EntityState.Modified;
            BL1.C_idBaiViet = (int)Session["DetailBV"];
            BL1.C_idUserDoc = Session["QuyenID"].ToString();
            BL1.ThoiDiemBinhLuan = DateTime.Now;
            BL1.CapBac = 2;


            //BL1.C_idBinhLuanGoc = idBinhLuan;
            //BL1.C_idBinhLuan = "11001100";
            db.BinhLuans.Add(BL1);
            db.SaveChanges();
            return RedirectToAction("DetailBaiViet", "NguoiViet", new { @idBaiViet = Session["DetailBV"] });


        }


    }
}