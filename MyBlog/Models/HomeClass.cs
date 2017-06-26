using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Areas.MyBlog.Models;

namespace MyBlog.Models
{
    public class HomeClass
    {
        public List<Article> ArticleList { get; set; }
        public Article Article { get; set; }
        public int Type { get; set; }
    }
}