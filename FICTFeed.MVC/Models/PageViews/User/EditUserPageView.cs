using FICTFeed.MVC.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.User
{
    public class EditUserPageView : BasePageView
    {
        public UserEditViewModel User { get; set; }

        public EditUserPageView(HttpRequestBase request, UserEditViewModel user)
            : base(request)
        {
            User = new UserEditViewModel(user.Name, user.Mail, user.Role);
        }

        public EditUserPageView(HttpRequestBase request)
            : base(request)
        {
            User = new UserEditViewModel();
        }

        public EditUserPageView()
        {
            User = new UserEditViewModel();
        }
    }
}