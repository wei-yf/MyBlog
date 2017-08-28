using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
using System.Data;
using MyBlog.Help;
using Dapper;
using MyBlog.Areas.MyBlog.Models;

namespace MyBlog.Controllers
{
    public class CunDangController : ApplicationController
    {
        // GET: CunDang
        public ActionResult Index()
        {
            CunDangClass cd = new CunDangClass();
            using (IDbConnection conn = DapperHelp.GetOpenConnection())
            {
                string sql = "select SUBSTRING(date,1,4) as year from Article group by SUBSTRING(date,1,4) order by SUBSTRING(date,1,4) desc";
                cd.YearList = conn.Query<YearClass>(sql).ToList();
                foreach(var v in cd.YearList)
                {
                    string sql2 = "select SUBSTRING(date,6,2) as month from Article where SUBSTRING(date,1,4)=@year group by SUBSTRING(date, 1, 7),SUBSTRING(date, 6, 2) ,SUBSTRING(date, 1, 4)order by SUBSTRING(date, 1, 7) desc";
                    v.MonthList = conn.Query<MonthClass>(sql2, new { year = v.Year }).ToList();
                    foreach(var m in v.MonthList)
                    {
                        string sql3 = "select * from Article where SUBSTRING(date,1,7)=@date";
                        m.ArticleList = conn.Query<Article>(sql3, new { date = v.Year + "-" + m.Month }).ToList();
                    }
                }
            }
                return View(cd);
        }
        public ActionResult tes()
        {
            return View();
        }
    }
}