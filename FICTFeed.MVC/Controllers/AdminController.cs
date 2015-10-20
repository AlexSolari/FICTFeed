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
using System.Threading.Tasks;

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
            var model = new EditUserPageView(Request, Mapper.Map<UserEditViewModel, User>(users));
            return View(model);
        }

        public ActionResult EditUserRole(string id)
        {
            var user = userManager.GetById(id);
            if (userManager.Update(user) == OperationResult.Success)
            {
                return RedirectToRoute("GetUsers");
            }
            //show error
            return View();
        }

    }
}