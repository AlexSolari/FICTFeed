﻿using FICTFeed.Framework.Users;
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
using FICTFeed.Framework.Shedule;
using FICTFeed.Framework.Extensions;

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
            if (user == null)
                return View();

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


        [HttpGet]
        public ActionResult CreateGroup()
        {
            return View(new CreateGroupPageView());
        }

        [HttpPost]
        public ActionResult CreateGroup(CreateGroupPageView model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var newGroup = model.NewGroup;
            groupsManager.Create(Mapper.Map<Group, GroupCreateViewModel>(newGroup));

            return RedirectToRoute("GetGroups");
        }

        [HttpGet]
        public ActionResult EditGroup(string id)
        {
            var groupRaw = groupsManager.GetById(id);

            if (groupRaw == null)
                return RedirectToRoute("NotFound");

            var group = Mapper.Map<GroupEditViewModel, Group>(groupRaw);

            return View(new GroupEditPageView(group));
        }

        [HttpPost]
        public ActionResult EditGroup(GroupEditPageView model)
        {
            var group = Mapper.Map<Group, GroupEditViewModel>(model.Group);

            groupsManager.Update(group);
            
            return RedirectToRoute("GetGroups");
        }
    }
}