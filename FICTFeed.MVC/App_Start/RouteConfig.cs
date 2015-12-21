using System.Web.Mvc;
using System.Web.Routing;

namespace FICTFeed.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region User

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
                name: "ForgotPassword",
                url: "forgotpassword",
                defaults: new { controller = "User", action = "ForgotPassword", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RestorePassword",
                url: "restore",
                defaults: new { controller = "User", action = "RestorePassword", id = UrlParameter.Optional }
            );

            #endregion

            #region News

            routes.MapRoute(
                name: "NewsCreate",
                url: "news/create",
                defaults: new { controller = "News", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NewsEdit",
                url: "news/edit",
                defaults: new { controller = "News", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NewsGetListForGroup",
                url: "news/listforgroup",
                defaults: new { controller = "News", action = "GetList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NewsItem",
                url: "news",
                defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional }
            );

            #endregion

            routes.MapRoute(
                name: "CommentCreate",
                url: "comment/create",
                defaults: new { controller = "Comments", action = "Create", id = UrlParameter.Optional }
            );

            #region Admin

            routes.MapRoute(
                name: "Admin",
                url: "admin",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "GetUsers",
                url: "admin/users",
                defaults: new { controller = "Admin", action = "GetUsers" }
            );

            routes.MapRoute(
                name: "GetGroups",
                url: "admin/groups",
                defaults: new { controller = "Admin", action = "GetGroups" }
            );

            routes.MapRoute(
                name: "GetNews",
                url: "admin/news",
                defaults: new { controller = "Admin", action = "GetNewsItem" }
            );

            routes.MapRoute(
                name: "EditUserRole",
                url: "edituserrole/{id}",
                defaults: new { controller = "Admin", action = "EditUserRole", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateGroup",
                url: "admin/creategroup",
                defaults: new { controller = "Admin", action = "CreateGroup" }
            );

            routes.MapRoute(
                name: "EditGroup",
                url: "admin/editgroup",
                defaults: new { controller = "Admin", action = "EditGroup" }
            );
            
            routes.MapRoute(
                name: "DeleteGroup",
                url: "admin/deletegroup",
                defaults: new { controller = "Admin", action = "DeleteGroup" }
            );

            #endregion

            #region Home

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

            #endregion

            #region Group

            routes.MapRoute(
                name: "GetSchedulePDF",
                url: "group/schedule",
                defaults: new { controller = "Group", action = "Schedule", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SchedulePDF",
                url: "group/schedulepdf",
                defaults: new { controller = "Group", action = "SchedulePDF" }
            );

            #endregion

            #region Errors

            routes.MapRoute(
                "NotFound",
                "{*url}",
             new { controller = "Error", action = "Index" }
            );

            #endregion


        }
    }
}
