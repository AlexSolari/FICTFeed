using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.ViewModels.Comments
{
    public class CommentCreateModel
    {
        public virtual string Description { get; set; }

        public virtual Guid AuthorId { get; set; }

        public virtual Guid NewsItemId { get; set; }

        public virtual DateTime PostingDate { get; set; }
    }
}