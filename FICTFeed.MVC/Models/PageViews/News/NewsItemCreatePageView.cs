using FICTFeed.Bussines.AdditionalData;
using FICTFeed.Bussines.Models;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Groups;
using FICTFeed.Framework.Users;
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
            var userData = new UserDataContainer();
            GroupIds = new Dictionary<string, string>();
            if (userData.IsAuthorized)
            {
                if (userData.CurrentUser.Role == Roles.Admin || userData.CurrentUser.Role == Roles.Moderator)
                {
                    foreach (var item in Resolver.GetInstance<IGroupsManager>().GetList())
                    {
                        GroupIds.Add(item.Name, item.Id.ToString());
                    }
                }
                else if (userData.CurrentUser.Role == Roles.Praepostor)
                {
                    var group = Resolver.GetInstance<IGroupsManager>().GetById(userData.CurrentUser.GroupId.ToString());
                    GroupIds.Add(group.Name, group.Id.ToString());
                }
            }
            
        }

    }
}