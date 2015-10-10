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
            return View();
        }
	}
}