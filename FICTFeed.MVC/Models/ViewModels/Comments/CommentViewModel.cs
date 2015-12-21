using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.ViewModels.Comments
{
    public class CommentViewModel
    {
        public virtual Guid Id { get; set; }

        public virtual string Description { get; set; }

        public virtual string AuthorName { get; set; }

        public virtual string PostingDateString { get; set; }
    }
}