using FICTFeed.MVC.Models.PageViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FICTFeed.MVC.Controllers
{
    public class UserController : Controller
    {
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
	}
}