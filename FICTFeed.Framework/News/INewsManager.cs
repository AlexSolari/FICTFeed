using FICTFeed.Bussines;
using FICTFeed.Framework.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.News
{
    public interface INewsManager : IManager<NewsItem>
    {
        IList<NewsItem> GetList(string orderBy = null, int? count = null);
        IList<NewsItem> GetListMatchingUserGroups(UserDataContainer userData, string orderBy = null, int? count = null);
    }
}
