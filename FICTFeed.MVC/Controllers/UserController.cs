using FICTFeed.MVC.Models.PageViews;
using FICTFeed.DependecyResolver;
using System;
using System.Web.Mvc;
using FICTFeed.Framework.Users;
using FICTFeed.Framework.Map;
using FICTFeed.Bussines;
using FICTFeed.Bussines.Models;
using FICTFeed.MVC.Models.ViewModels;
using FICTFeed.Framework.Strings;
using FICTFeed.MVC.Models.PageViews.User;
using FICTFeed.MVC.Models.ViewModels.User;
using FICTFeed.Framework.Groups;
using FICTFeed.Framework;

namespace FICTFeed.MVC.Controllers
{
    public class UserController : Controller
    {
        IUserManager userManager;
        IGroupsManager groupsManager;

        public UserController()
        {
            userManager = Resolver.GetInstance<IUserManager>();
            groupsManager = Resolver.GetInstance<IGroupsManager>();
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
            userManager.Register(Mapper.Map<FICTFeed.Bussines.Models.User,UserCreateViewModel>(newUser));
            userManager.Login(pageView.NewUser.Mail, pageView.NewUser.Password);

            return RedirectToRoute("Home");
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

            if (userManager.Login(pageView.LoginData.Mail, pageView.LoginData.Password) != OperationResult.Success)
            {
                pageView.Valid = false;
                return View(pageView);
            }

            return RedirectToRoute("Home");
        }

        [HttpGet]
        public ActionResult LogoutUser()
        {
            var result = userManager.Logout();

            if (result == OperationResult.Success)
                Response.Cookies[CookiesNames.LoginCookie].Expires = DateTime.Now.AddDays(-1d);
            return RedirectToRoute("Home");
        }


        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string mail)
        {
            userManager.RestorePassword(mail);
            return View("MailSent");
        }
        [HttpGet]
        public ActionResult RestorePassword(string user, string token)
        {
            var usermodel = userManager.GetById(user);

            if (usermodel == null)
                return RedirectToRoute("NotFound");

            var expectedToken = Resolver.GetSingleton<Encryptor>().GenerateToken(usermodel);

            if (expectedToken != token)
                return RedirectToRoute("NotFound");

            return View(new RestorePasswordPageView(usermodel.Id.ToString()));
        }

        [HttpPost]
        public ActionResult RestorePassword(RestorePasswordPageView model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = userManager.GetById(model.UserId);

            user.PasswordCrypted = Resolver.GetSingleton<Encryptor>()
                .CryptPassword(model.NewPass.Password);

            userManager.Update(user);
            userManager.Login(user.Mail, model.NewPass.Password);

            return View("Updated");
        }
    }
}