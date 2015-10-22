using FICTFeed.Bussines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.Groups
{
    public class GroupsManager : IGroupsManager
    {
        protected GroupsDataProvider provider = new GroupsDataProvider();

        public Group GetById(string id)
        {
            return provider.GetById(id);
        }

        public void Create(Group model)
        {
            provider.Create(model);
        }

        public void Delete(Group group)
        {
            provider.Delete(group);
        }

        public void Update(Group group)
        {
            provider.Update(group);
        }

        public IList<Group> GetList(string orderBy = null)
        {
            return provider.GetList(orderBy);
        }
    }
}
