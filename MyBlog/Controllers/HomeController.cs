using MyBlog.Help;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using MyBlog.Areas.MyBlog.Models;


namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            List<Article> aList = new List<Article>();
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                aList = conn.Query<Article>("select * from Article").ToList();
            }
                return View(aList);
        }
    }
}
