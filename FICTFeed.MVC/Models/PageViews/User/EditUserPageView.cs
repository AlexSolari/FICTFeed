﻿using FICTFeed.MVC.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.User
{
    public class EditUserPageView : BasePageView
    {
        public IEnumerable<UserEditViewModel> Users { get; set; }

        public EditUserPageView(HttpRequestBase request, IEnumerable<UserEditViewModel> users)
            : base(request)
        {
            Users = users;
        }

        public EditUserPageView(HttpRequestBase request)
            : base(request)
        {
            Users = new List<UserEditViewModel>();
        }

        public EditUserPageView()
        {
            Users = new List<UserEditViewModel>();
        }
    }
}