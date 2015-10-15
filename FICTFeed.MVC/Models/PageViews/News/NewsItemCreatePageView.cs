using FICTFeed.MVC.Models.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.News
{
    public class NewsItemCreatePageView : BasePageView
    {
        public NewsItemViewModel NewNewsItem { get; set; }

        public NewsItemCreatePageView(HttpRequestBase request)
            : base(request)
        {
            NewNewsItem = new NewsItemViewModel();
        }

        public NewsItemCreatePageView()
        {
            NewNewsItem = new NewsItemViewModel();
        }
    }
}