using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Areas.MyBlog.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string ArtUrl { get; set; }
        public string ImgUrl { get; set; }
        public string Tag { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public string Theme { get; set; }
        public string Describe { get; set; }
        [AllowHtml]
        public string Blog { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime DeletedOn { get; set; }
    }
    public class AtricleYeShu
    {
        public int YeShu { get; set; }
        public List<Article> ArticleList { get; set; }
        public int PageCount { get; set; }
        public int RowsCount { get; set; }
    }
}