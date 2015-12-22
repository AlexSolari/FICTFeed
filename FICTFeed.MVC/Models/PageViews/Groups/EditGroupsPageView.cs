using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Users;
using FICTFeed.MVC.Models.ViewModels.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.Groups
{
    public class EditGroupsPageView : BasePageView
    {
        public IEnumerable<GroupEditViewModel> Groups { get; set; }

        public Dictionary<Guid, IEnumerable<Bussines.Models.User>> Users { get; set; }

        public EditGroupsPageView(IEnumerable<GroupEditViewModel> groups)
            : base()
        {
            Groups = groups;

            Users = new Dictionary<Guid, IEnumerable<Bussines.Models.User>>();

            var userManager = Resolver.GetInstance<IUserManager>();

            var users = userManager.GetList();

            foreach (var item in groups)
            {
                Users.Add(item.Id, users.Where(x=>x.GroupId == item.Id));
            }
        }

        public EditGroupsPageView()
        {
            Groups = new List<GroupEditViewModel>();
            Users = new Dictionary<Guid, IEnumerable<Bussines.Models.User>>();
        }
    }
}