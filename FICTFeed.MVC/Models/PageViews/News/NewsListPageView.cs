using FICTFeed.Bussines;
using FICTFeed.Bussines.Models;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Groups;
using FICTFeed.Framework.Map;
using FICTFeed.Framework.News;
using FICTFeed.MVC.Models.ViewModels.News;
using FICTFeed.Resources;
using FICTFeed.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FICTFeed.MVC.Models.PageViews.News
{
    public class NewsListPageView : BasePageView
    {
        public List<NewsItemViewModel> News;

        protected INewsManager newsManager;

        public IEnumerable<System.Web.Mvc.SelectListItem> Groups
        {
            get
            {
                var groups = new List<SelectListItem>();
                var manager = FICTFeed.DependecyResolver.Resolver.GetInstance<FICTFeed.Framework.Groups.IGroupsManager>();
                var globalGroup = manager.GetByName("Global");
                string localizedGlobalGroupName = ResourceAccessor.Instance.Get("Global");

                groups.Add(new SelectListItem() { Text = ResourceAccessor.Instance.Get("AllNews"), Value = "All", Selected = true });
                groups.Add(new SelectListItem() { Text = ResourceAccessor.Instance.Get("NewsFor").FormatWith(localizedGlobalGroupName), Value = globalGroup.Name });

                if (UserData.CurrentUser.Role == FICTFeed.Bussines.AdditionalData.Roles.User || UserData.CurrentUser.Role == FICTFeed.Bussines.AdditionalData.Roles.Praepostor)
                {
                    var usergroup = (manager.GetById(UserData.CurrentUser.GroupId.ToString()).Name);
                    groups.Add(new SelectListItem() { Text = ResourceAccessor.Instance.Get("NewsFor").FormatWith(usergroup), Value = usergroup });
                }
                else
                {
                    foreach (var item in manager.GetList())
                    {
                        if (item.Name != globalGroup.Name)
                            groups.Add(new SelectListItem() { Text = ResourceAccessor.Instance.Get("NewsFor").FormatWith(item.Name), Value = item.Name });
                    }
                }

                return groups;
            }
        }

        public NewsListPageView()
            : base()
        {
            newsManager = Resolver.GetInstance<INewsManager>();
            News = new List<NewsItemViewModel>();
            News.AddRange(newsManager.GetList("PostingDate").Select(x => Mapper.Map<NewsItemViewModel, NewsItem>(x)));
        }

        public NewsListPageView(IEnumerable<NewsItemViewModel> news)
            : base()
        {
            newsManager = Resolver.GetInstance<INewsManager>();
            News = news.ToList();
        }
    }
}