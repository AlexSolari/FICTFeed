﻿using FICTFeed.MVC.Models.ViewModels;
using FICTFeed.MVC.Models.ViewModels.User;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.User
{
    public class LoginUserPageView : BasePageView
    {
        public UserLoginViewModel LoginData { get; set; }
        public bool Valid { get; set; }

        public LoginUserPageView()
            : base()
        {
            Valid = true;
            LoginData = new UserLoginViewModel();
        }

    }
}