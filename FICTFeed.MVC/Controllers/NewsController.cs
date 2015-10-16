using FICTFeed.Bussines;
using FICTFeed.Framework.News;
using FICTFeed.Framework.Users;
using FICTFeed.MVC.Models.PageViews.News;
using FICTFeed.MVC.Models.ViewModels.News;
using FICTFeed.DependecyResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FICTFeed.Framework.Map;

namespace FICTFeed.MVC.Controllers
{
    public class NewsController : Controller
    {
        protected INewsManager newsManager;

        public NewsController()
        {
            newsManager = Resolver.GetInstance<INewsManager>();
        }

        [HttpGet]
        public ActionResult Index(string id)
        {
            Guid tmp;
            //TODO: implement manager "news creation call" instead of direct call
            //var a = new FICTFeed.Framework.NHibernate.DataProvider<NewsItem>();
            if (!Guid.TryParse(id, out tmp) || newsManager.GetById(id) == null)
                return RedirectToRoute("Home");

            return View(new NewsItemPageView(Request, id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new NewsItemCreatePageView(Request));
        }

        [HttpPost]
        public ActionResult Create(NewsItemCreatePageView pageView)
        {
            var userdata = new UserDataContainer(Request);
            if (!ModelState.IsValid)
                return View(pageView);

            var newNewsItem = pageView.NewNewsItem;
            newNewsItem.PrapareToPosting(userdata.CurrentUser.Id.ToString());

            //TODO: implement manager "news creation call" instead of direct call
            //var a = new FICTFeed.Framework.NHibernate.DataProvider<NewsItem>();

            //a.Create(FICTFeed.Framework.Map.Mapper.Map<NewsItem, NewsItemViewModel>(newNewsItem));

            newsManager.Create(Mapper.Map<NewsItem, NewsItemViewModel>(newNewsItem));
            //

            return RedirectToRoute("Home");
        }
    }
}