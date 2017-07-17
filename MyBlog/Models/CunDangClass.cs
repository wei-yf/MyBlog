using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Areas.MyBlog.Models;

namespace MyBlog.Models
{
    public class CunDangClass
    {
        public List<YearClass> YearList { get; set; }
    }

    public class YearClass
    {
        public string Year { get; set; }
        public List<MonthClass> MonthList { get; set; }
    }
    public class MonthClass
    {
        public string Month { get; set; }
        public List<Article> ArticleList { get; set; }
    }
}