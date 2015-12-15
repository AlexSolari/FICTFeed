﻿using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.ViewModels.Comments
{
    public class CommentCreateModel
    {
        public virtual Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [CustomizebleStringLength(250, 1)]
        public virtual string Description { get; set; }

        public virtual Guid AuthorId { get; set; }

        public virtual Guid NewsItemId { get; set; }

        public virtual DateTime PostingDate { get; set; }

        public CommentCreateModel()
        {
            Id = Guid.NewGuid();
            PostingDate = DateTime.Now;
        }
    }
}