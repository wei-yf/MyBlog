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
        public ActionResult Index(int yeshu=1)
        {
            AtricleYeShu ays = new AtricleYeShu();
            //using (IDbConnection conn = DapperHelp.GetOpenConnection())
            //{
            //    ays.ArticleList = conn.Query<Article>("select * from Article where DeletedOn is null  order by createOn desc").ToList();
            //}
            ays = getPage(ays, yeshu);
            return View(ays);
        }

        public ActionResult Blog(int id)
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                var sql = "select * from Article where DeletedOn is null and id=@id";
                Article a = conn.Query<Article>(sql, new { id = id }).FirstOrDefault();
                return PartialView("Blog_Detail", a);
            }
        }
        public ActionResult Page(int yeshu = 1)
        {
            AtricleYeShu ays = new AtricleYeShu();
            ays = getPage(ays, yeshu);
            return PartialView("Index_BlogList", ays);
        }
        private static AtricleYeShu getPage(AtricleYeShu ays, int yeshu)
        {
            ays.YeShu = yeshu;
            ays.ArticleList = new List<Article>();
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                ays.RowsCount = conn.Query<Article>("select * from Article where DeletedOn is null order by createOn desc").Count();
                ays.PageCount = ays.RowsCount / 7;
                if (ays.RowsCount % 7 > 0)
                {
                    ays.PageCount = ays.PageCount + 1;
                }
                ays.ArticleList = conn.Query<Article>("select top 7 * from Article where DeletedOn is null and id not in (select top " + ((yeshu - 1) * 7) + " id from Article order by createOn desc) order by createOn desc").ToList();
            }
            return ays;
        }
    }
}
