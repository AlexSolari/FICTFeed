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
            var userInfo = new UserDataContainer();

            var news = newsManager.GetListMatchingUserGroups(userInfo, "PostingDate");
            var result = new NewsListPageView(Mapper.Map<NewsItemViewModel, NewsItem>(news));

            return View(result);
        }
    }
}