using FICTFeed.Bussines;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Map;
using FICTFeed.Framework.News;
using FICTFeed.Framework.Users;
using FICTFeed.MVC.Models.PageViews;
using FICTFeed.MVC.Models.PageViews.News;
using FICTFeed.MVC.Models.ViewModels.News;
using System.Web.Mvc;
using System.Linq;
using FICTFeed.Framework.Strings;
using System;

namespace FICTFeed.MVC.Controllers
{
    public class HomeController : Controller
    {
        protected INewsManager newsManager;

        public HomeController()
        {
            newsManager = Resolver.GetInstance<INewsManager>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Request.Cookies.AllKeys.Contains(CookiesNames.LandingVisited))
            {
                var userInfo = new UserDataContainer();

                var news = newsManager.GetListMatchingUserGroups(userInfo, "PostingDate");
                var result = new NewsListPageView(Mapper.Map<NewsItemViewModel, NewsItem>(news));

                return View(result);
            }

            return RedirectToRoute("Landing");
        }

        [HttpGet]
        public ActionResult Landing()
        {
            Request.RequestContext.HttpContext.Response.Cookies.Add(new System.Web.HttpCookie(CookiesNames.LandingVisited, Guid.NewGuid().ToString()));

            return View(new BasePageView());
        }
    }
}