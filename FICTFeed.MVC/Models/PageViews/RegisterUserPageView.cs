using FICTFeed.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews
{
    public class RegisterUserPageView
    {
        public UserViewModel NewUser { get; set; }

        public RegisterUserPageView()
        {
            NewUser = new UserViewModel();
        }
    }
}