using FICTFeed.MVC.Models.PageViews;
using System.Web.Mvc;

namespace FICTFeed.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new BasePageView(Request));
        }
    }
}