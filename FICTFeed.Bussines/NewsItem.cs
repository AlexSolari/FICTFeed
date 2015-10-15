using FICTFeed.Bussines.AdditionalData;
using System;
namespace FICTFeed.Bussines
{
    public class NewsItem : Entity
    {
        public virtual string Title { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string Description { get; set; }
        public virtual string AuthorId { get; set; }
        public virtual DateTime PostingDate { get; set; }
    }
}
