using FICTFeed.Framework.Users;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FICTFeed.Bussines.AdditionalData;
using FICTFeed.MVC.Models.PageViews;

namespace FICTFeed.MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (!RequireRole(Roles.Admin))
                return RedirectToRoute("Home");

            return View(new BasePageView(Request));
        }

        bool RequireRole(Roles role)
        {
            var currentUser = new UserDataContainer(Request).CurrentUser;
            return (Guard.HaveEnoughRights(currentUser, role));
        }
    }
}