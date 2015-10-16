using FICTFeed.Framework.Users;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FICTFeed.Bussines.AdditionalData;
using FICTFeed.MVC.Models.PageViews;
using System.Web.Routing;

namespace FICTFeed.MVC.Controllers
{
    public class AdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!(new UserDataContainer(Request).IsInRole(Roles.Admin)))
            {
                filterContext.Result = RedirectToRoute("Default");
            }
        }
        
        // GET: Admin
        public ActionResult Index()
        {
            return View(new BasePageView(Request));
        }
    }
}