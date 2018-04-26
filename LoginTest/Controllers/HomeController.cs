using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.Models;
using Facebook;
using System.Configuration;
using System.Web.Security;

namespace LoginTest.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            // Lan luot tao cac viewbag de lay list san pham tu co so du lieu
            //List Công nghệ  
            var lstCN = db.BaiViets.Where(n => n.C_idTheLoai == 1).ToList();
            // Gán vào Viewbag
            ViewBag.ListCN = lstCN;

            //List Học Tập 
            var lstHT = db.BaiViets.Where(n => n.C_idTheLoai == 2).ToList();
            // Gán vào Viewbag
            ViewBag.ListHT = lstHT;

            //List Thủ Thuật 
            var lstTT = db.BaiViets.Where(n => n.C_idTheLoai == 3).ToList();
            // Gán vào Viewbag
            ViewBag.ListTT = lstTT;

            return View();
        }
        //public ActionResult Comment(string idBV)
        //{
        //    var lstComment = db.BinhLuans.Where(x => x.C_idBaiViet == idBV).ToList();
        //    ViewBag.ListCM1 = lstComment;
        //    return RedirectToAction("DetailBaiViet");
        //}
        //public User GetById(string Usename)
        //{
        //    return db.Users.SingleOrDefault(x => x.Usename == Usename);
        //}

        /// <summary>
        /// dự phòng
        /// </summary>
        //public ActionResult HomeNguoiViet(int? UserName)
        //{
        //    //var user = db.Users.Where(x => x.Id == id).SingleOrDefault();
        //    var guser = db.Users.Where(x => x.Quyen == 4).SingleOrDefault();
        //    if (guser != null)
        //    {
        //        return View();
        //        //return Redirect("/");
        //    }
        //    //var guser = db.Users.ToList();
        //    // return View();
        //    return Redirect("/");
        //}


        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        public object CommonConstants { get; private set; }

        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });
           // var urs = db.Users.Single(x => x.Usename == )
           // Session["user"] = 

            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });


            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;
                string id = me.id;
                string picture = string.Format("https://graph.facebook.com/{0}/picture", id);


                var user = new User();
                    user.C_idUser = id;
                    user.Usename = email;
                    user.GioiTinh = true;
                    user.HoTen = firstname + " " + middlename + " " + lastname;
                    user.NgayDangKy = DateTime.Now;
                    user.Hinh = picture;          
                    user.Quyen = 3;
                var user1 = db.Users.SingleOrDefault(x => x.C_idUser == user.C_idUser);
                    if (user1 == null)
                    {
                        db.Users.Add(user); 
                        db.SaveChanges();
                        Session["UserName"] = user.Usename.ToString();
                        return RedirectToAction("Index", "Home");
                }
                //return RedirectToAction("AdminNhomNguoiDung2");
                Session["UserName"] = user1.Usename.ToString();
                Session["HoTen"] = user1.HoTen.ToString();
                Session["QuyenID"] = user1.C_idUser.ToString();

                return RedirectToAction("Index", "Home");
                //return View();
                // return Redirect("/");


            }
            return Redirect("/");
        }

        public ActionResult Logout ()
        {
            Session["UserName"] = null;
            Session["HoTen"] = null;
            Session["QuyenID"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}