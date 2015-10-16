using FICTFeed.Bussines.AdditionalData;
using FICTFeed.Framework.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FICTFeed.MVC.Components.User
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class AllowToAttribute : ActionFilterAttribute, IActionFilter
    {
        public Roles Role { get; set; }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = HttpContext.Current.Request.RequestContext.HttpContext.Request;
            if (!(new UserDataContainer(request).IsInRole(Role)))
            {
                filterContext.Result = new RedirectResult("error/not-found");
            }
        }

        public AllowToAttribute(Roles Role)
        {
            this.Role = Role;
        }
    }
}