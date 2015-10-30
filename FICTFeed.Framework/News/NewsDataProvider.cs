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
    public class NewsDataProvider : DataProvider<NewsItem>
    {
        public NewsItem GetByAuthorId(string authorId)
        {
            return base.Execute<NewsItem>(session =>
                {
                    var criteria = session.CreateCriteria(typeof(NewsItem));
                    criteria.Add(Restrictions.Eq("AuthorId", authorId));
                    return criteria.UniqueResult<NewsItem>();
                });
        }

        public IList<NewsItem> GetList(string orderBy = null, List<Guid> groups = null)
        {
            return Execute(session =>
            {
                var criteria = session.CreateCriteria<NewsItem>();
                if (!String.IsNullOrWhiteSpace(orderBy))
                    criteria = criteria.AddOrder(Order.Desc(orderBy));
                if (groups != null)
                {
                    var groupSelector = Restrictions.Disjunction();
                    foreach (var item in groups)
                    {
                        groupSelector.Add(Restrictions.Eq("GroupId", item));
                    }
                    criteria.Add(groupSelector);
                }
                return criteria.List<NewsItem>();
            });
        }
    }
}
