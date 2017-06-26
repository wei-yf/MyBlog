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
        [Route("home/index")]
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

        public ActionResult Blog(int id)
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                var sql = "select * from Article where id=@id";
                Article a = conn.Query<Article>(sql, new { id = id }).FirstOrDefault();
                return PartialView("Blog_Detail", a);
            }
        }
    }
}
