using FICTFeed.Bussines.AdditionalData;
using FICTFeed.Bussines.Models;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Groups;
using FICTFeed.Framework.Users;
using FICTFeed.MVC.Models.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.News
{
    public class NewsItemEditPageView : BasePageView
    {
        public NewsItemEditViewModel NewsItem { get; set; }

        public NewsItemEditPageView()
            : base()
        {
            NewsItem = new NewsItemEditViewModel();
        }

    }
}