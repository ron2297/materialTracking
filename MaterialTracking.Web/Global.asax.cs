using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MaterialTracking.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string path = Server.MapPath("~/bin");
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
