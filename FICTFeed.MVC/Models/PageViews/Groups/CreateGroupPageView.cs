using FICTFeed.MVC.Models.ViewModels.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.Groups
{
    public class CreateGroupPageView : BasePageView
    {
        public GroupCreateViewModel NewGroup { get; set; }

        public CreateGroupPageView()
            : base()
        {
            NewGroup = new GroupCreateViewModel();
        }
    }
}