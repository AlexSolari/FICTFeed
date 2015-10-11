using FICTFeed.Database.NHibernate;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FICTFeed.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected SessionHelper _sessionHelper = null;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FrameworkInitializer.Start();
        }
    }
}
