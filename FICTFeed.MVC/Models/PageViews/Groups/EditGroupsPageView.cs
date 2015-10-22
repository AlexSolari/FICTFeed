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

        public EditGroupsPageView(IEnumerable<GroupEditViewModel> groups)
            : base()
        {
            Groups = groups;
        }

        public EditGroupsPageView()
        {
            Groups = new List<GroupEditViewModel>();
        }
    }
}