using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Help;
using Newtonsoft.Json;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class ApplicationController : Controller
    {
        public ApplicationController()
        {
            Dictionary<string, string> para = new Dictionary<string, string>();
            para.Add("city", "青岛");
            string backstr=RequestHelp.getreq(@"https://www.toutiao.com/stream/widget/local_weather/data", para);
            WeatherClass we=JsonConvert.DeserializeObject<WeatherClass>(backstr);
            ViewBag.Weather = we;
        }
    }
}