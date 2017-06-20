using System.Web.Mvc;

namespace MyBlog.Areas.MyBlog
{
    public class MyBlogAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MyBlog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MyBlog_default",
                "MyBlog/{controller}/{action}/{id}",
                new { action="index" , id = UrlParameter.Optional }
            );
        }
    }
}