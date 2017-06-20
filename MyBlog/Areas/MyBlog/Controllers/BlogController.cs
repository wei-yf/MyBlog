using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Areas.MyBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: MyBlog/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}