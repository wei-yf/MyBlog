using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using System.Text;

namespace MyBlog.Help
{
    public class ReturnHelp
    {
        public static HttpResponseMessage toJson(Object obj)
        {
            string str;
            if (obj is string || obj is char)
            {
                str = obj.ToString();
            }else
            {
                str = JsonConvert.SerializeObject(obj);
            }
            HttpResponseMessage rem = new HttpResponseMessage
            {
                Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json")
            };
            return rem;
        }


    }
}