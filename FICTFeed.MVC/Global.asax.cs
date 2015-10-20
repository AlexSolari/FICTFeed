using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FICTFeed.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(FICTFeed.MVC.Models.ViewModels.User.UserEditViewModel), new FICTFeed.MVC.Components.ModelBinders.UserEditViewModelBinder());
            FrameworkInitializer.Start();
        }
    }
}
