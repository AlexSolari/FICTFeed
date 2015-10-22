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

        public EditUserPageView(IEnumerable<UserEditViewModel> users)
            : base()
        {
            Users = users;
        }

        public EditUserPageView()
            : base()
        {
            Users = new List<UserEditViewModel>();
        }
    }
}