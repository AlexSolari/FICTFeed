using FICTFeed.Bussines;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Map;
using FICTFeed.Framework.News;
using FICTFeed.MVC.Models.ViewModels.Comments;
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

        public IEnumerable<CommentViewModel> Comments;

        protected INewsManager newsManager;

        protected ICommentsManager commentsManager;

        public NewsItemPageView(string id)
            : base()
        {
            newsManager = Resolver.GetInstance<INewsManager>();
            commentsManager = Resolver.GetInstance<ICommentsManager>();
            NewsItem = Mapper.Map<NewsItemViewModel, NewsItem>(newsManager.GetById(id));
            Comments = Mapper.Map<CommentViewModel, Comment>(commentsManager.GetList(NewsItem.Id));
        }

        public NewsItemPageView()
            : base()
        {
            NewsItem = new NewsItemViewModel();
        }
    }
}