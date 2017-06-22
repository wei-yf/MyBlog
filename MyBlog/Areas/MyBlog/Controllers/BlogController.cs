﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data;
using MyBlog.Help;
using MyBlog.Areas.MyBlog.Models;

namespace MyBlog.Areas.MyBlog.Controllers
{
    public class BlogController : Controller
    {
        [ValidateInput(false)]
        // GET: MyBlog/Home
        public ActionResult Index(int id)
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                var sql = "select * from Article where id=@id";
                Article a = conn.Query<Article>(sql, new { id = id }).FirstOrDefault();
                return View(a);
            }
        }

        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]//关闭注入验证
        public ActionResult EditeResult(string theme,string tag,string describe,string blog)
        {
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                Article ar = new Article
                {
                    Author = "位亚飞",
                    Tag = tag,
                    Date = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                    Theme = theme,
                    Describe=describe,
                    Blog = blog
                };
                string sql = "insert into Article(author,tag,date,theme,describe,blog) values(@author,@tag,@date,@theme,@describe,@blog)";
                int n =conn.Execute(sql, ar);
                if(n>0)
                {
                    ViewBag.Message = "发布成功";
                }else
                {
                    ViewBag.Message = "发布失败";
                }
                return View();
            }
        }
    }
}