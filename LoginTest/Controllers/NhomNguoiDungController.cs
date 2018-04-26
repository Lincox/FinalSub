using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.Models;

namespace LoginTest.Controllers
{
    public class NhomNguoiDungController : Controller
    {
        // GET: NhomNguoiDung
        Model1 db = new Model1();
        public ActionResult AdminNhomNguoiDung()
        {
            //var user = db.Users.Where(x => x.Id == id).SingleOrDefault();
            var guser = db.Users.Where(x => x.Quyen == 1).ToList();// load theo quyen.
            //var guser = db.Users.ToList();
            return View(guser);
        }

        public ActionResult AdminNhomNguoiDung2()
        {
            //var user = db.Users.Where(x => x.Id == id).SingleOrDefault();
            var guser = db.Users.Where(x => x.Quyen == 4).ToList();// load theo quyen.
            //var guser = db.Users.ToList();
            return View(guser);
        }

        public ActionResult AdminNhomNguoiDung3()
        {
            //var user = db.Users.Where(x => x.Id == id).SingleOrDefault();
            var guser = db.Users.Where(x => x.Quyen == 3).ToList();// load theo quyen.
            //var guser = db.Users.ToList();
            return View(guser);
        }

        [HttpGet]
        public ActionResult ThemNhomNguoiDung()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemNhomNguoiDung(User guser)
        {
            db.Users.Add(guser);
            db.SaveChanges();
            return RedirectToAction("AdminNhomNguoiDung");
        }


        //public ActionResult InsertForFacebook(User guser)
        //{
        //    var user = db.Users.SingleOrDefault(x => x.Usename == guser.Usename);
        //    if (user == null)
        //    {
        //        db.Users.Add(guser);
        //        db.SaveChanges();
        //        return RedirectToAction("AdminNhomNguoiDung");
        //    }
        //    else
        //    {
        //        return RedirectToAction("AdminNhomNguoiDung"); 
        //    }
        //}

        public ActionResult XoaNhomNguoiDung(string idUser)
        {
            User guser = db.Users.SingleOrDefault(n => n.C_idUser == idUser);
            if (guser == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Users.Remove(guser);
            db.SaveChanges();
            return RedirectToAction("AdminNhomNguoiDung");
        }


       
        [HttpGet]
        public ActionResult CapNhatNguoiDung(string idUser)
        {
            User guser = db.Users.SingleOrDefault(n => n.C_idUser == idUser);
            if (guser == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(guser);
        }

        [HttpPost]
        public ActionResult CapNhatNguoiDung(User guser)
        {
            db.Entry(guser).State = System.Data.Entity.EntityState.Modified;
            //guser.Quyen = "2";
            db.SaveChanges();
            return RedirectToAction("AdminNhomNguoiDung");
        }

        [HttpGet]
        public ActionResult CapNhatNguoiDung2(string idUser)
        {
            User guser = db.Users.SingleOrDefault(n => n.C_idUser == idUser);
            if (guser == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(guser);
        }
        [HttpPost]
        public ActionResult CapNhatNguoiDung2(User guser)
        {
            db.Entry(guser).State = System.Data.Entity.EntityState.Modified;
           // guser.Quyen = "2";
            db.SaveChanges();
            return RedirectToAction("AdminNhomNguoiDung2");
        }

        public ActionResult XoaNhomNguoiDung2(string idUser)
        {
            User guser = db.Users.SingleOrDefault(n => n.C_idUser == idUser);
            if (guser == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Users.Remove(guser);
            db.SaveChanges();
            return RedirectToAction("AdminNhomNguoiDung2");
        }
        [HttpGet]
        public ActionResult CapNhatNguoiDung3(string idUser)
        {
            User guser = db.Users.SingleOrDefault(n => n.C_idUser == idUser);
            if (guser == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(guser);
        }
        [HttpPost]
        public ActionResult CapNhatNguoiDung3(User guser)
        {
            db.Entry(guser).State = System.Data.Entity.EntityState.Modified;
            guser.Quyen = 4;
            db.SaveChanges();
            return RedirectToAction("AdminNhomNguoiDung3");
        }

    }
}