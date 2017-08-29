using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MyBlog.Help
{
    public class RequestHelp
    {
        public static string getreq(string url, Dictionary<string, string> para)
        {
            url = buildUrl(url, para);
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
        public static string postreq(string url, Dictionary<string, string> para, string postStr)
        {
            url = buildUrl(url, para);
            HttpWebRequest req= (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = Encoding.UTF8.GetByteCount("");
            byte[] bytes = Encoding.UTF8.GetBytes(postStr);
            var reqStream = req.GetRequestStream();
            reqStream.Write(bytes, 0, bytes.Length);
            reqStream.Close();

            var respStream = req.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(respStream);

            return sr.ReadToEnd();
        }
        public static string buildUrl(string url, Dictionary<string, string> para)
        {
            if (para.Count > 0)
            {
                url = url + "?";
                int n = 0;
                foreach (var item in para)
                {
                    if (n == 0)
                    {
                        url += item.Key + "=" + item.Value;
                    }
                    else
                    {
                        url += "&" + item.Key + "=" + item.Value;
                    }
                    n++;
                }
            }
            return url;
        }
    }
}