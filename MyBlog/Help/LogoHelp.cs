using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace MyBlog.Help
{
    public class LogoHelp
    {
        public static void WriteLogo(string msg)
        {
            string text = "\r\n" + msg + "\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + "===============================================" + "\r\n";
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string path = HttpContext.Current.Server.MapPath("/logo/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fs = File.Open(path + fileName, FileMode.OpenOrCreate))
            {
                byte[] mybyte = Encoding.UTF8.GetBytes(text);
                fs.Position = fs.Length;
                fs.Write(mybyte, 0, mybyte.Length - 1);
            }
        }
    }
}