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

        public IList<NewsItem> GetList(string orderBy = null, int? count = null)
        {
            return provider.GetList(orderBy, count);
        }

        public IList<NewsItem> GetListForGroup(string groupName, string orderBy = "PostingDate", int? count = null)
        {
            var groupManager = Resolver.GetInstance<IGroupsManager>();
            var groups = new List<Guid>();
            groups.Add(groupManager.GetByName(groupName).Id);
            return provider.GetList(orderBy, count, groups);
        }

        public IList<NewsItem> GetListMatchingUserGroups(UserDataContainer userData, string orderBy = "PostingDate", int? count = null)
        {
            var groupManager = Resolver.GetInstance<IGroupsManager>();
            var groups = new List<Guid>();
            if (userData.IsAuthorized)
            {
                switch (userData.CurrentUser.Role)
                {
                    case Bussines.AdditionalData.Roles.User:
                    case Bussines.AdditionalData.Roles.Praepostor:
                        groups.Add(userData.CurrentUser.GroupId);
                        break;
                    case Bussines.AdditionalData.Roles.Moderator:
                    case Bussines.AdditionalData.Roles.Admin:
                        foreach (var item in groupManager.GetList())
                            groups.Add(item.Id);
                        break;
                    default:
                        break;
                }
            }
            groups.Add(groupManager.GetByName("Global").Id);
            return provider.GetList(orderBy, count, groups);
        }

        public void Update(NewsItem obj)
        {
            provider.Update(obj);
        }

        public void Delete(NewsItem item)
        {
            provider.Delete(item);
        }
    }
}
