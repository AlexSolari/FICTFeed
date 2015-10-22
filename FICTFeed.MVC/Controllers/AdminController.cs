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
using FICTFeed.Framework.Groups;
using FICTFeed.MVC.Models.PageViews.Groups;
using FICTFeed.MVC.Models.ViewModels.Groups;
using FICTFeed.Bussines.Models;

namespace FICTFeed.MVC.Controllers
{
    [AllowTo(Roles.Admin)]
    public class AdminController : Controller
    {
        IUserManager userManager;
        IGroupsManager groupsManager;

        public AdminController()
        {
            userManager = Resolver.GetInstance<IUserManager>();
            groupsManager = Resolver.GetInstance<IGroupsManager>();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(new BasePageView());
        }

        public ActionResult GetUsers()
        {
            var users = userManager.GetList();
            var model = new EditUserPageView(Mapper.Map<UserEditViewModel, User>(users));
            return View(model);
        }

        public ActionResult EditUserRole(UserEditViewModel model)
        {
            var user = userManager.GetById(model.Id.ToString());
            user.Role = model.Role;
            if (userManager.Update(user) == OperationResult.Success)
            {
                return RedirectToRoute("GetUsers");
            }
            //show error
            return RedirectToRoute("GetUsers");
        }

        public ActionResult GetGroups()
        {
            var groups = groupsManager.GetList();
            var model = new EditGroupsPageView(Mapper.Map<GroupEditViewModel, Group>(groups));
            return View(model);
        }

        public ActionResult EditGroupName(GroupEditViewModel model)
        {
            var group = groupsManager.GetById(model.Id.ToString());
            group.Name = model.Name;
            groupsManager.Update(group);
            return RedirectToRoute("GetGroups");
        }

        [HttpGet]
        public ActionResult CreateGroup()
        {
            return View(new GroupCreateViewModel());
        }

        [HttpPost]
        public ActionResult CreateGroup()
        {
            //create group
            return RedirectToRoute("GetGroups");
        }

    }
}