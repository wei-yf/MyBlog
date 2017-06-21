using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Areas.MyBlog.Models
{
    public class Article
    {
        public int id { get; set; }
        public string artUrl { get; set; }
        public string imgUrl { get; set; }
        public string tag { get; set; }
        public string author { get; set; }
        public string date { get; set; }
        public string theme { get; set; }
        public string describe { get; set; }
        [AllowHtml]
        public string article { get; set; }
    }
}