using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MyBlog
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public WebApiApplication()
        {
            AuthenticateRequest += WebApiApplication_AuthenticateRequest;
        }
        /// <summary>
        /// 给当前用户添加角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebApiApplication_AuthenticateRequest(object sender, EventArgs e)
        {
            if(Context.User!=null)
            {
                IIdentity id = Context.User.Identity;
                if (id.IsAuthenticated)
                {
                    if (id.Name == "admina")
                    {
                        Context.User = new GenericPrincipal(id, new string[1] { "wyf" });
                    }
                }
            }

            if(Context.User!=null)
            {
                var idd = Context.User.Identity as FormsIdentity;
                if (idd != null && idd.IsAuthenticated)
                {
                    var roles = new string[1] { "asdasd" };
                    Context.User = new GenericPrincipal(idd, roles);
                }
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
