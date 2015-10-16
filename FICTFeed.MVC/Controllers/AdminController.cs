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
using FICTFeed.MVC.Components.User;

namespace FICTFeed.MVC.Controllers
{
    [AllowTo(Roles.Admin)]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View(new BasePageView(Request));
        }
    }
}