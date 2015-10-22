using FICTFeed.MVC.Models.PageViews;
using FICTFeed.MVC.Models.PageViews.News;
using System.Web.Mvc;

namespace FICTFeed.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new NewsListPageView());
        }
    }
}