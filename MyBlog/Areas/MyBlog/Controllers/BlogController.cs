using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data;
using MyBlog.Help;
using MyBlog.Areas.MyBlog.Models;
using System.Globalization;

namespace MyBlog.Areas.MyBlog.Controllers
{
    public class BlogController : Controller
    {
        [ValidateInput(false)]
        // GET: MyBlog/Home
        public ActionResult Index(int yeshu=1)
        {
            AtricleYeShu ays = new AtricleYeShu();
            ays = getPage(ays, yeshu);
            return View(ays);
        }

        public ActionResult Edit(int? id)
        {
            //Article a=new Article();
            if (id!=null)
            {
                using (IDbConnection conn = DapperHelp.GetOpenConnection())
                {
                    Article a = conn.Query<Article>("select * from article where @id=id", new { id = id }).First();
                    return View(a);
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]//关闭注入验证
        public ActionResult EditeResult(int id,string theme,string tag,string describe,string blog)
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                if(id==0)
                {
                    Article ar = new Article
                    {
                        Author = "位亚飞",
                        Tag = tag,
                        Date = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                        Theme = theme,
                        Describe = describe,
                        Blog = blog
                    };
                    string sql = "insert into Article(author,tag,date,theme,describe,blog) values(@author,@tag,@date,@theme,@describe,@blog)";
                    int n = conn.Execute(sql, ar);
                    if (n > 0)
                    {
                        ViewBag.Message = "发布成功";
                    }
                    else
                    {
                        ViewBag.Message = "发布失败";
                    }
                }else
                {
                    string sql = "update  article set tag=@tag,theme=@theme,describe=@describe,blog=@blog where id=@id";
                    int n = conn.Execute(sql, new { tag = tag, theme = theme, describe = describe, blog = blog, id = id });
                }
                
                return RedirectToAction("Index", "Blog");
            }
        }
        public ActionResult del(int id,int yeshu=1)
        {
            AtricleYeShu ays = new AtricleYeShu();
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                int n =conn.Execute("delete  from Article where id=@id", new { id = id });
            }
            ays = getPage(ays, yeshu);
            return PartialView("Index_partical", ays);
        }

        public ActionResult Page(int yeshu=1)
        {
            AtricleYeShu ays = new AtricleYeShu();
            ays = getPage(ays, yeshu);
            return PartialView("Index_partical", ays);
        }

        private static AtricleYeShu getPage(AtricleYeShu ays,int yeshu)
        {
            ays.YeShu = yeshu;
            ays.ArticleList = new List<Article>();
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                ays.RowsCount = conn.Query<Article>("select * from Article").Count();
                ays.PageCount = ays.RowsCount / 10;
                if(ays.RowsCount%10>0)
                {
                    ays.PageCount = ays.PageCount + 1;
                }
                ays.ArticleList = conn.Query<Article>("select top 10 * from Article where id not in (select top " + ((yeshu - 1) * 10) + " id from Article)").ToList();
            }
            return ays;
        }
    }
}