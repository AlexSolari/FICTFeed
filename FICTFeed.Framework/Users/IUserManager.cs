using FICTFeed.Bussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FICTFeed.Framework.Users
{
    public interface IUserManager : IManager<User>
    {
        OperationResult Register(User user);

        OperationResult Login(string mail, string passwordRaw);

        OperationResult Logout();
    }
}
