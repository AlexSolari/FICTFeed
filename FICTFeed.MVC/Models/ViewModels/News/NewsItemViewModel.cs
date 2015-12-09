﻿using FICTFeed.Bussines.AdditionalData;
using FICTFeed.Framework.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FICTFeed.MVC.Models.ViewModels.News
{
    public class NewsItemViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public virtual Guid Id { get; set; }

        [StringLength(100, ErrorMessage = "Title must be between 3 and 100 characters", MinimumLength = 3)]
        [Required]
        [AllowHtml]
        public virtual string Title { get; set; }

        [StringLength(300, ErrorMessage = "Short description must be lesser than 300 characters")]
        [Required]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public virtual string ShortDescription { get; set; }

        [StringLength(1000, ErrorMessage = "Description must be lesser than 1000 characters")]
        [Required]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public virtual string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual Guid AuthorId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual Guid GroupId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual DateTime PostingDate { get; set; }
        
        public NewsItemViewModel() { }

        public NewsItemViewModel(string title, string shortDescription, string description, Guid authorId)
        {
            Guard.ThrowIfEmptyString(title);
            Guard.ThrowIfEmptyString(shortDescription);
            Guard.ThrowIfEmptyString(description);
            Guard.ThrowIfEmptyGuid(authorId);

            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            AuthorId = authorId;
        }

        public void PrapareToPosting(Guid userId)
        {
            PostingDate = DateTime.Now;
            AuthorId = userId;
            Id = Guid.NewGuid();
        }
    }
}