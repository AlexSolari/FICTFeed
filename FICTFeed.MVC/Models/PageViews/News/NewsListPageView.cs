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
    public class NewsListPageView : BasePageView
    {
        public List<NewsItemViewModel> News;

        protected INewsManager newsManager;

        public NewsListPageView(HttpRequestBase request)
            : base(request)
        {
            newsManager = Resolver.GetInstance<INewsManager>();
            News = new List<NewsItemViewModel>();
            News.AddRange(newsManager.GetList("PostingDate").Select(x => Mapper.Map<NewsItemViewModel, NewsItem>(x)));
        }

        public NewsListPageView()
        {
            newsManager = Resolver.GetInstance<INewsManager>();
            News = new List<NewsItemViewModel>();
            News.AddRange(newsManager.GetList("PostingDate").Select(x => Mapper.Map<NewsItemViewModel, NewsItem>(x)));
        }
    }
}