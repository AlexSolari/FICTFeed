using FICTFeed.Bussines.AdditionalData;
using System;
namespace FICTFeed.Bussines
{
    public class Comment : Entity
    {
        public virtual string Description { get; set; }

        public virtual Guid NewsItemId { get; set; }

        public virtual Guid AuthorId { get; set; }
        
        public virtual DateTime PostingDate { get; set; }
    }
}
