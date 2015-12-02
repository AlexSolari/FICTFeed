﻿using System.Web.Mvc;
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

            #endregion

            #region News

            routes.MapRoute(
                name: "NewsCreate",
                url: "news/create",
                defaults: new { controller = "News", action = "Create", id = UrlParameter.Optional }
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
