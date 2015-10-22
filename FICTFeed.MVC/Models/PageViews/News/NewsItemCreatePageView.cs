using FICTFeed.Bussines.Models;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Groups;
using FICTFeed.MVC.Models.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.News
{
    public class NewsItemCreatePageView : BasePageView
    {
        public NewsItemViewModel NewNewsItem { get; set; }

        public Dictionary<string, string> GroupIds { get; set; }

        public NewsItemCreatePageView()
            : base()
        {
            NewNewsItem = new NewsItemViewModel();
            GroupIds = new Dictionary<string, string>();
            foreach (var item in Resolver.GetInstance<IGroupsManager>().GetList())
            {
                GroupIds.Add(item.Name, item.Id.ToString());
            }
        }

    }
}