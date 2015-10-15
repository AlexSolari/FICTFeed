using System.Web.Mvc;
using System.Web.Routing;

namespace FICTFeed.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "RegisterUser",
                url: "registration",
                defaults: new { controller = "User", action = "RegisterUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "LoginUser",
                url: "login",
                defaults: new { controller = "User", action = "LoginUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "LogoutUser",
                url: "logout",
                defaults: new { controller = "User", action = "LogoutUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NewsCreate",
                url: "news/create",
                defaults: new { controller = "News", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "home",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
