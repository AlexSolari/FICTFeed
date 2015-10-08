using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FICTFeed.MVC.NHibernate.Providers;
using FICTFeed.Bussines;

namespace FICTFeed.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var a = new DataProvider<TestEntity>();
            for (int i = 0; i < 13; i++)
            {
                a.Create(new TestEntity());
            }
            return View();
        }
    }
}