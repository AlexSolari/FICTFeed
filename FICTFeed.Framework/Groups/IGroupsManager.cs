using FICTFeed.Bussines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.Groups
{
    public interface IGroupsManager : IManager<Group>
    {
        IList<Group> GetList(string orderBy = null);

        void Delete(Group group);

        void Update(Group group);
    }
}
