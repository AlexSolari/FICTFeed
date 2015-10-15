using FICTFeed.Bussines;
using FICTFeed.Framework.Map;
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

        public NewsItemPageView(HttpRequestBase request, string id)
            : base(request)
        {
            //TODO: Implement getting new from manager instead of direct get
            NewsItem = new NewsItemViewModel();
            var a = new FICTFeed.Framework.NHibernate.DataProvider<NewsItem>();
            NewsItem = Mapper.Map<NewsItemViewModel, NewsItem>(a.GetById(id));
        }

        public NewsItemPageView()
        {
            NewsItem = new NewsItemViewModel();
        }
    }
}