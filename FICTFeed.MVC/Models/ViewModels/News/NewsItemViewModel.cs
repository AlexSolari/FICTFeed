using FICTFeed.Bussines.AdditionalData;
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

        [StringLength(100, ErrorMessage = "Must be between 10 and 100 characters", MinimumLength = 10)]
        [Required]
        public virtual string Title { get; set; }

        [StringLength(300, ErrorMessage="Must be lesser than 300 characters")]
        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string ShortDescription { get; set; }

        [StringLength(1000, ErrorMessage = "Must be lesser than 1000 characters")]
        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual string AuthorId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual DateTime PostingDate { get; set; }
        
        public NewsItemViewModel() { }

        public NewsItemViewModel(string title, string shortDescription, string description, string authorId)
        {
            Guard.ThrowIfEmptyString(title);
            Guard.ThrowIfEmptyString(shortDescription);
            Guard.ThrowIfEmptyString(description);
            Guard.ThrowIfEmptyString(authorId);

            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            AuthorId = authorId;
        }

        public void PrapareToPosting(string userId)
        {
            PostingDate = DateTime.Now;
            AuthorId = userId;
        }
    }
}