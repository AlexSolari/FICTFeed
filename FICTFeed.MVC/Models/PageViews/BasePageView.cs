﻿using FICTFeed.Framework.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews
{
    public class BasePageView
    {
        public UserDataContainer UserData;

        public BasePageView()
        {
            UserData = new UserDataContainer();
        }
    }
}