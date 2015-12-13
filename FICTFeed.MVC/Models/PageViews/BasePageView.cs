using FICTFeed.Framework.News;
using FICTFeed.Framework.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews
{
    public class BasePageView
    {
        public UserDataContainer UserData = new UserDataContainer();

        public Dictionary<Guid, string> NewestNews = new Dictionary<Guid, string>();

        public BasePageView()
        {
            var manager = DependecyResolver.Resolver.GetInstance<INewsManager>();

            foreach (var item in manager.GetListMatchingUserGroups(UserData, "PostingDate", 5))
            {
                NewestNews.Add(item.Id, item.Title);
            }
        }
    }
}