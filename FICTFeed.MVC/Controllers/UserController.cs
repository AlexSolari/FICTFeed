using FICTFeed.MVC.Models.PageViews;
using FICTFeed.DependecyResolver;
using System;
using System.Web.Mvc;
using FICTFeed.Framework.Users;

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
            return View(new RegisterUserPageView());
        }

        [HttpPost]
        public ActionResult RegisterUser(RegisterUserPageView pageView)
        {
            if (!ModelState.IsValid)
                return View(pageView);

            var newUser = pageView.NewUser;
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult LoginUser()
        {
            return View(new LoginUserPageView());
        }

        [HttpPost]
        public ActionResult LoginUser(LoginUserPageView pageView)
        {
            if (!ModelState.IsValid)
                return View(pageView);

            throw new NotImplementedException();
            userManager.Login(pageView.LoginData.Mail, pageView.LoginData.Password, Request);
        }
	}
}