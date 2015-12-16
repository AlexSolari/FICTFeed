using FICTFeed.Bussines.Models;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Groups;
using FICTFeed.MVC.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.User
{
    public class EditUserPageView : BasePageView
    {
        public IEnumerable<UserEditViewModel> Users { get; set; }

        protected readonly IList<Group> groups;

        public IEnumerable<System.Web.Mvc.SelectListItem> Groups
        {
            get
            {
                if (groups.Any(x => x.Name == "Global"))
                {
                    groups.First(x => x.Name == "Global").Name = Resources.ResourceAccessor.Instance.Get("Global");
                }
                return new System.Web.Mvc.SelectList(groups, "Id", "Name");
            }
        }

        public EditUserPageView(IEnumerable<UserEditViewModel> users)
            : base()
        {
            groups = Resolver.GetInstance<IGroupsManager>().GetList();
            Users = users;
        }

        public EditUserPageView()
            : base()
        {
            Users = new List<UserEditViewModel>();
        }
    }
}