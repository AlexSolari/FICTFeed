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
using FICTFeed.Framework.Map;
using FICTFeed.MVC.Models.ViewModels.User;
using FICTFeed.Bussines;
using FICTFeed.DependecyResolver;
using FICTFeed.MVC.Models.PageViews.User;

namespace FICTFeed.MVC.Controllers
{
    [AllowTo(Roles.Admin)]
    public class AdminController : Controller
    {
        IUserManager userManager;

        public AdminController()
        {
            userManager = Resolver.GetInstance<IUserManager>();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(new BasePageView(Request));
        }

        public ActionResult GetUsers()
        {
            var users = userManager.GetList();
            var usersList = Mapper.Map<UserEditViewModel, User>(users);
            return View(new EditUserPageView(Request));
        }
    }
}