using FICTFeed.Bussines;
using FICTFeed.Framework.NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.News
{
    public class CommentsDataProvider : DataProvider<Comment>
    {
        public IList<Comment> GetByAuthorId(Guid authorId)
        {
            return base.Execute(session =>
                {
                    var criteria = session.CreateCriteria(typeof(Comment));
                    criteria.Add(Restrictions.Eq("AuthorId", authorId));
                    criteria.AddOrder(Order.Desc("PostingDate"));
                    return criteria.List<Comment>();
                });
        }

        public IList<Comment> GetByNewsId(Guid id)
        {
            return base.Execute(session =>
            {
                var criteria = session.CreateCriteria(typeof(Comment));
                criteria.Add(Restrictions.Eq("NewsItemId", id));
                criteria.AddOrder(Order.Desc("PostingDate"));
                return criteria.List<Comment>();
            });
        }
    }
}
