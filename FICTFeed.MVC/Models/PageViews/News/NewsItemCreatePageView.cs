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

        //public Dictionary<string, string> GroupIds { get; set; }

        protected readonly List<Group> groups;

        public IEnumerable<System.Web.Mvc.SelectListItem> Groups
        {
            get
            {
                if (groups.Any(x=>x.Name == "Global"))
                {
                    groups.First(x => x.Name == "Global").Name = Resources.ResourceAccessor.Instance.Get("Global");
                }
                return new System.Web.Mvc.SelectList(groups, "Id", "Name");
            }
        }

        public NewsItemCreatePageView()
            : base()
        {
            NewNewsItem = new NewsItemViewModel();
            var userData = new UserDataContainer();
            groups = new List<Group>();
            if (userData.IsAuthorized)
            {
                if (userData.CurrentUser.Role == Roles.Admin || userData.CurrentUser.Role == Roles.Moderator)
                {
                    foreach (var item in Resolver.GetInstance<IGroupsManager>().GetList())
                    {
                        groups.Add(item);
                    }
                }
                else if (userData.CurrentUser.Role == Roles.Praepostor)
                {
                    var group = Resolver.GetInstance<IGroupsManager>().GetById(userData.CurrentUser.GroupId.ToString());
                    groups.Add(group);
                }
            }
            
        }

    }
}