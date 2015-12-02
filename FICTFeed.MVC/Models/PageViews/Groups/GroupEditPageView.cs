using FICTFeed.MVC.Models.ViewModels.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.Groups
{
    public class GroupEditPageView : BasePageView
    {
        public GroupEditViewModel Group { get; set; }

        public GroupEditPageView(GroupEditViewModel group)
            : base()
        {
            Group = group;
        }

        public GroupEditPageView()
        {
            Group = null;
        }
    }
}