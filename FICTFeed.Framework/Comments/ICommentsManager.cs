using FICTFeed.Bussines;
using FICTFeed.Framework.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.News
{
    public interface ICommentsManager : IManager<Comment>
    {
        IList<Comment> GetList();
        IList<Comment> GetList(Guid newsItemId);
    }
}
