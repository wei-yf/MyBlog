using MyBlog.Help;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

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
                //aList.Add(a);
                return View(aList);
        }


    }

    public class Article
    {
        public string artUrl { get; set; }
        public string imgUrl { get; set; }
        public string tag { get; set; }
        public string author { get; set; }
        public string date { get; set; }
        public string theme { get; set; }
        public string describe { get; set; }
    }

}
