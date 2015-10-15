using FICTFeed.Bussines;
using FICTFeed.Framework.Users;
using FICTFeed.MVC.Models.PageViews.News;
using FICTFeed.MVC.Models.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FICTFeed.MVC.Controllers
{
    public class NewsController : Controller
    {
        [HttpGet]
        public ActionResult Index(string id)
        {
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
            var a = new FICTFeed.Framework.NHibernate.DataProvider<NewsItem>();
            a.Create(FICTFeed.Framework.Map.Mapper.Map<NewsItem, NewsItemViewModel>(newNewsItem));
            //

            return RedirectToRoute("Home");
        }
    }
}