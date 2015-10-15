using FICTFeed.MVC.Models.PageViews;
using FICTFeed.DependecyResolver;
using System;
using System.Web.Mvc;
using FICTFeed.Framework.Users;
using FICTFeed.Framework.Map;
using FICTFeed.Bussines;
using FICTFeed.MVC.Models.ViewModels;
using FICTFeed.Framework.Strings;
using FICTFeed.MVC.Models.PageViews.User;
using FICTFeed.MVC.Models.ViewModels.User;

namespace FICTFeed.MVC.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager;

        public UserController()
        {
            userManager = Resolver.GetInstance<UserManager>();
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View(new RegisterUserPageView(Request));
        }

        [HttpPost]
        public ActionResult RegisterUser(RegisterUserPageView pageView)
        {
            if (!ModelState.IsValid)
                return View(pageView);

            var newUser = pageView.NewUser;
            userManager.Register(Mapper.Map<User,UserCreateViewModel>(newUser));

            return RedirectToRoute("Home");
        }

        [HttpGet]
        public ActionResult LoginUser()
        {
            return View(new LoginUserPageView(Request));
        }

        [HttpPost]
        public ActionResult LoginUser(LoginUserPageView pageView)
        {
            if (!ModelState.IsValid)
                return View(pageView);

            if (userManager.Login(pageView.LoginData.Mail, pageView.LoginData.Password, Response) != UserManager.OperationResult.Success)
            {
                pageView.Valid = false;
                return View(pageView);
            }

            return RedirectToRoute("Home");
        }

        [HttpGet]
        public ActionResult LogoutUser()
        {
            var result = userManager.Logout(Request);

            if (result == UserManager.OperationResult.Success)
                Response.Cookies[CookiesNames.LoginCookie].Expires = DateTime.Now.AddDays(-1d);
            return RedirectToRoute("Home");
        }
    }
}