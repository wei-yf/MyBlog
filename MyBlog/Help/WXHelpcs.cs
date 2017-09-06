using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace MyBlog.Help
{
    public class WXHelpcs
    {
        //开发者密码：
        //AppID:wx415cf740ff9c7701
        //AppSecret:8c2232ba74316363c9d3c22ca80e0095
        public static string access_token="";
        public static int expires_in = 0;
        public static int errcode = 0;
        public static string errmsg = "";
        public static void getAccess_token()
        {
            Dictionary<string, string> para = new Dictionary<string, string>();
            para.Add("grant_type", "client_credential");
            para.Add("appid", "wx415cf740ff9c7701");
            para.Add("secret", "8c2232ba74316363c9d3c22ca80e0095");

           string rep= RequestHelp.getreq(@"https://api.weixin.qq.com/cgi-bin/token", para);
            LogoHelp.WriteLogo(rep);
            AcccessToken at=JsonConvert.DeserializeObject<AcccessToken>(rep);
            access_token = at.access_token;
            expires_in = at.expires_in;
            errcode = at.errcode;
            errmsg = at.errmsg;
        }
    }
    public class AcccessToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public int errcode { get; set; }
        public string errmsg { get; set; }

    }

}