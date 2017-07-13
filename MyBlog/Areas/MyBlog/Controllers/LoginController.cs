using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlog.Areas.MyBlog.Controllers
{
    public class LoginController : Controller
    {
        // GET: MyBlog/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string userName, string Password)
        {
            
            if (userName == "admina" && Password == "123")
            {
                FormsAuthentication.RedirectFromLoginPage(userName, false);
            }
            else
            {
                return Content("<script>alert('密码错误');history.go(-1);</script>");
            }
            return View();
            //return RedirectToAction("index", "Test");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}