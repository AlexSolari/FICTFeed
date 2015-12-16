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
using FICTFeed.Bussines.AdditionalData;

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
            if (!Guid.TryParse(id, out tmp) || newsManager.GetById(id) == null)
                return RedirectToRoute("Home");

            return View(new NewsItemPageView(id));
        }

        [HttpPost]
        public ActionResult GetList(string groupName)
        {
            var userdata = new UserDataContainer();
            IEnumerable<NewsItemViewModel> news;
            if (groupName != "All")
                news = Mapper.Map<NewsItemViewModel, NewsItem>(newsManager.GetListForGroup(groupName));
            else
                news = Mapper.Map<NewsItemViewModel, NewsItem>(newsManager.GetListMatchingUserGroups(userdata));

            var result = new NewsListPageView(news);
            return PartialView("NewsList", result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new NewsItemCreatePageView());
        }

        [HttpPost]
        public ActionResult Create(NewsItemCreatePageView pageView)
        {
            var userdata = new UserDataContainer();
            if (!ModelState.IsValid)
                return View(pageView);

            var newNewsItem = pageView.NewNewsItem;
            newNewsItem.PrapareToPosting(userdata.CurrentUser.Id);
            newsManager.Create(Mapper.Map<NewsItem, NewsItemViewModel>(newNewsItem));

            return RedirectToRoute("Home");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var userdata = new UserDataContainer();
            var newsItem = newsManager.GetById(id);

            if (newsItem == null || !userdata.IsAuthorized)
                return RedirectToRoute("NotFound");

            if (userdata.CurrentUser.Id == newsItem.AuthorId 
                || userdata.CurrentUser.Role == Roles.Admin 
                || userdata.CurrentUser.Role == Roles.Moderator
                || (userdata.CurrentUser.Role == Roles.Praepostor && userdata.CurrentUser.GroupId == newsItem.GroupId))
            {
                var mapped = Mapper.Map<NewsItemEditViewModel, NewsItem>(newsItem);
                return View(new NewsItemEditPageView() { NewsItem = mapped });
            }
            else
            {
                return RedirectToRoute("NotFound");
            }
        }

        [HttpPost]
        public ActionResult Edit(NewsItemEditPageView model)
        {
            var mapped = Mapper.Map<NewsItem, NewsItemEditViewModel>(model.NewsItem);
            newsManager.Update(mapped);
            var returnUrl = Request.Form.Get("returnUrl");
            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToRoute("Home");

            return Redirect(returnUrl);
        }
    }
}