using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginTest.Models;

namespace LoginTest.Controllers
{
    public class QuanLyBaiVietController : Controller
    {
        private Model1 db = new Model1();

        // GET: QuanLyBaiViet
        public ActionResult Index()
        {
            var baiViets = db.BaiViets.Include(b => b.TheLoai).Include(b => b.User);
            return View(baiViets.ToList());
        }

        // GET: QuanLyBaiViet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // GET: QuanLyBaiViet/Create
        public ActionResult Create()
        {
            
            ViewBag.C_idTheLoai = new SelectList(db.TheLoais, "C_idTheLoai", "TheLoai1");
            ViewBag.C_idUserDang = new SelectList(db.Users, "C_idUser", "HoTen");
            return View();
        }

        // POST: QuanLyBaiViet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "C_idBaiViet,C_idTheLoai,C_idUserDang,TieuDe,TomTatNoiDung,AnhBia,NgayDang,NgayChinhSua,NoiDung,SoLanXem,TrangThaiBaiViet")]
        BaiViet baiViet, HttpPostedFileBase NoiDung, HttpPostedFileBase aAnhBia)
        {
            db.Entry(baiViet).State = System.Data.Entity.EntityState.Modified;
            baiViet.C_idUserDang = Session["QuyenID"].ToString();
            if (ModelState.IsValid)
            {
                if (aAnhBia != null)
                {
                    baiViet.AnhBia = new byte[aAnhBia.ContentLength];
                    aAnhBia.InputStream.Read(baiViet.AnhBia, 0, aAnhBia.ContentLength);
                }
                baiViet.NgayDang = DateTime.Now;
                baiViet.NgayChinhSua = DateTime.Now;
                baiViet.TrangThaiBaiViet = false;

                db.BaiViets.Add(baiViet);
                db.SaveChanges();
                return RedirectToAction("HomeNguoiViet", "NguoiViet", new { @C_idUser = Session["QuyenID"] });
            }

            ViewBag.C_idTheLoai = new SelectList(db.TheLoais, "C_idTheLoai", "TheLoai1", baiViet.C_idTheLoai);
            ViewBag.C_idUserDang = new SelectList(db.Users, "C_idUser", "HoTen", baiViet.C_idUserDang);
            return View(baiViet);
        }

        // GET: QuanLyBaiViet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_idTheLoai = new SelectList(db.TheLoais, "C_idTheLoai", "TheLoai1", baiViet.C_idTheLoai);
            ViewBag.C_idUserDang = new SelectList(db.Users, "C_idUser", "HoTen", baiViet.C_idUserDang);
            return View(baiViet);
        }

        // POST: QuanLyBaiViet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "C_idBaiViet,C_idTheLoai,C_idUserDang,TieuDe,TomTatNoiDung,AnhBia,NgayDang,NgayChinhSua,NoiDung,SoLanXem,TrangThaiBaiViet")]
        BaiViet baiViet, HttpPostedFileBase NoiDung, HttpPostedFileBase aAnhBia)
        {
            if (ModelState.IsValid)
            {
                if (aAnhBia != null)
                {
                    baiViet.AnhBia = new byte[aAnhBia.ContentLength];
                    aAnhBia.InputStream.Read(baiViet.AnhBia, 0, aAnhBia.ContentLength);
                }
                baiViet.C_idUserDang = Session["QuyenID"].ToString();
                baiViet.NgayChinhSua = DateTime.Now;
                baiViet.TrangThaiBaiViet = true;

                db.Entry(baiViet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HomeNguoiViet", "NguoiViet", new { @C_idUser = Session["QuyenID"] });
            }

            ViewBag.C_idTheLoai = new SelectList(db.TheLoais, "C_idTheLoai", "TheLoai1", baiViet.C_idTheLoai);
            ViewBag.C_idUserDang = new SelectList(db.Users, "C_idUser", "HoTen", baiViet.C_idUserDang);
            return View(baiViet);
        }

        // GET: QuanLyBaiViet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            //return View(baiViet);
            db.BaiViets.Remove(baiViet);
            db.SaveChanges();
            return RedirectToAction("HomeNguoiViet", "NguoiViet", new { @C_idUser = Session["QuyenID"] });
        }

        // POST: QuanLyBaiViet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiViet baiViet = db.BaiViets.Find(id);
            db.BaiViets.Remove(baiViet);
            db.SaveChanges();
            return RedirectToAction("HomeNguoiViet", "NguoiViet", new { @C_idUser = Session["QuyenID"] });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
