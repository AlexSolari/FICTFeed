using FICTFeed.Bussines;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Map;
using FICTFeed.Framework.News;
using FICTFeed.MVC.Models.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.News
{
    public class NewsItemPageView : BasePageView
    {
        public NewsItemViewModel NewsItem;

        protected INewsManager newsManager;

        public NewsItemPageView(HttpRequestBase request, string id)
            : base(request)
        {
            newsManager = Resolver.GetInstance<INewsManager>();
            NewsItem = Mapper.Map<NewsItemViewModel, NewsItem>(newsManager.GetById(id));
        }

        public NewsItemPageView()
        {
            NewsItem = new NewsItemViewModel();
        }
    }
}