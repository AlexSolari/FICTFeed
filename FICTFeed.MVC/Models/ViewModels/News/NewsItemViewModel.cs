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

        [CustomizebleStringLength(100, 3)]
        [СustomizebleRequired]
        [AllowHtml]
        public virtual string Title { get; set; }

        [CustomizebleStringLength(300, 3)]
        [СustomizebleRequired]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public virtual string ShortDescription { get; set; }

        [CustomizebleStringLength(1000, 3)]
        [СustomizebleRequired]
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