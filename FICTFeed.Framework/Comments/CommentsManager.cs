using FICTFeed.Bussines;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Groups;
using FICTFeed.Framework.Users;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.News
{
    public class CommentsManager : ICommentsManager
    {
        protected CommentsDataProvider provider = new CommentsDataProvider();

        public void Create(Comment newsItem)
        {
            Guard.ThrowIfNull(newsItem);

            provider.Create(newsItem);
        }

        public Comment GetById(string id)
        {
            Guard.ThrowIfEmptyString(id);

            return provider.GetById(id);
        }

        public IList<Comment> GetList()
        {
            return provider.GetList();
        }

        public IList<Comment> GetList(Guid newsItemId)
        {
            return provider.GetByNewsId(newsItemId);
        }
    }
}
