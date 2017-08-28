using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace MyBlog.Help
{
    public class RequestHelp
    {
        public static string getreq(string url, Dictionary<string, string> para)
        {
            if(para.Count>0)
            {
                url = url + "?";
                int n = 0;
                foreach(var item in para)
                {
                    if (n == 0)
                    {
                        url += item.Key + "=" + item.Value;
                    }else
                    {
                        url += "&" + item.Key + "=" + item.Value;
                    }
                    n++;
                }
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
            string backstr = sr.ReadToEnd();
            sr.Close();
            res.Close();
            return backstr;
        }
    }
}