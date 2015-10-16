using FICTFeed.Bussines.AdditionalData;
using FICTFeed.Framework.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FICTFeed.MVC.Components.User
{
    public class OnlyAdminAccess : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = HttpContext.Current.Request.RequestContext.HttpContext.Request;
            if (!(new UserDataContainer(request).IsInRole(Roles.Admin)))
            {
                filterContext.Result = new RedirectResult("error/not-found");
            }
        }
    }
}