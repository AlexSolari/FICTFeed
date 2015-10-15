using FICTFeed.Bussines;
using FICTFeed.Framework.Map;
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

        public NewsListPageView(HttpRequestBase request)
            : base(request)
        {
            //TODO: Implement getting new from manager instead of direct get
            News = new List<NewsItemViewModel>();
            var a = new FICTFeed.Framework.NHibernate.DataProvider<NewsItem>();
            News.AddRange(a.GetList("PostingDate").Select(x => Mapper.Map<NewsItemViewModel, NewsItem>(x)));
        }

        public NewsListPageView()
        {
            //TODO: Implement getting new from manager instead of direct get
            News = new List<NewsItemViewModel>();
            var a = new FICTFeed.Framework.NHibernate.DataProvider<NewsItem>();
            News.AddRange(a.GetList("PostingDate").Select(x => Mapper.Map<NewsItemViewModel, NewsItem>(x)));
        }
    }
}