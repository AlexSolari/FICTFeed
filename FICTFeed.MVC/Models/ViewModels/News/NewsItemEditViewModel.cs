using FICTFeed.Bussines.AdditionalData;
using FICTFeed.Framework.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FICTFeed.MVC.Models.ViewModels.News
{
    public class NewsItemEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public virtual Guid Id { get; set; }

        [CustomizebleStringLength(250, 3)]
        [СustomizebleRequired]
        [AllowHtml]
        public virtual string Title { get; set; }

        [CustomizebleStringLength(1000, 3)]
        [СustomizebleRequired]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public virtual string ShortDescription { get; set; }

        [CustomizebleStringLength(4000, 3)]
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

        public NewsItemEditViewModel() { }
    }
}