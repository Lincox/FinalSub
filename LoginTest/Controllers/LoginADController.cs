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
    public class LoginADController : Controller
    {
        // GET: LoginAD
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XemTrangChu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                using (Model1 db = new Model1())
                {
                    var obj = db.Users.Where(a => a.Usename.Equals(user.Usename) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                       Session["UserID"] = obj.C_idUser.ToString();
                       Session["UserNameAD"] = obj.Usename.ToString();
                       return RedirectToAction("XemTrangChu");
                    }
                }
            }
            return Content("Tài khoản hoặc mật khẩu không đúng!");
        }
        //private Uri RedirectUri
        //{
        //    get
        //    {
        //        var uriBuilder = new UriBuilder(Request.Url);
        //        uriBuilder.Query = null;
        //        uriBuilder.Fragment = null;
        //        uriBuilder.Path = Url.Action("FacebookCallback");
        //        return uriBuilder.Uri;
        //    }
        //}

        //public object CommonConstants { get; private set; }

        //public ActionResult LoginFacebook()
        //{
        //    var fb = new FacebookClient();
        //    var loginUrl = fb.GetLoginUrl(new
        //    {
        //        client_id = ConfigurationManager.AppSettings["FbAppId"],
        //        client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
        //        redirect_uri = RedirectUri.AbsoluteUri,
        //        response_type = "code",
        //        scope = "email",
        //    });

        //    return Redirect(loginUrl.AbsoluteUri);
        //}
        //public ActionResult FacebookCallback(string code)
        //{
        //    var fb = new FacebookClient();
        //    dynamic result = fb.Post("oauth/access_token", new
        //    {
        //        client_id = ConfigurationManager.AppSettings["FbAppId"],
        //        client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
        //        redirect_uri = RedirectUri.AbsoluteUri,
        //        code = code
        //    });


        //    var accessToken = result.access_token;
        //    if (!string.IsNullOrEmpty(accessToken))
        //    {
        //        fb.AccessToken = accessToken;
        //        // Get the user's information, like email, first name, middle name etc
        //        dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
        //        string email = me.email;
        //        string userName = me.email;
        //        string firstname = me.first_name;
        //        string middlename = me.middle_name;
        //        string lastname = me.last_name;
        //        string id = me.id;

        //        var user = new User();
        //        user.C_idUser = id;
        //        user.Usename = email;
        //        user.GioiTinh = true;
        //        user.HoTen = firstname + " " + middlename + " " + lastname;
        //        user.NgayDangKy = DateTime.Now;
        //        db.Users.Add(user);
        //        db.SaveChanges();
        //        return RedirectToAction("AdminNhomNguoiDung");
        //        //var resultInsert = new NhomNguoiDungController().InsertForFacebook(user);

        //    }
        //    return Redirect("/");
        //}

        

        //public long InsertForFacebook(User entity)
        //{
        //    var user = db.Users.SingleOrDefault(x => x.Usename == entity.Usename);
        //    if (user == null)
        //    {
        //        db.Users.Add(entity);
        //        db.SaveChanges();
        //        return entity.idUser;
        //    }
        //    else
        //    {
        //        return user.idUser;
        //    }
        //}
    }

    }
