using FICTFeed.MVC.Models.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.Comments
{
    public class CommentPartialViewModel : BasePageView
    {
        public CommentViewModel Item { get; set; }

        public CommentPartialViewModel()
            : base()
        {
            Item = new CommentViewModel();
        }
    }
}