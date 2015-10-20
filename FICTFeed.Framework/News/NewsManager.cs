using FICTFeed.Bussines;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.News
{
    public class NewsManager : INewsManager
    {
        protected NewsDataProvider provider = new NewsDataProvider();

        public void Create(NewsItem newsItem)
        {
            Guard.ThrowIfNull(newsItem);

            provider.Create(newsItem);
        }

        public NewsItem GetById(string id)
        {
            Guard.ThrowIfEmptyString(id);

            return provider.GetById(id);
        }

        public IList<NewsItem> GetList(string orderBy = null)
        {
            return provider.GetList(orderBy);
        }
    }
}
