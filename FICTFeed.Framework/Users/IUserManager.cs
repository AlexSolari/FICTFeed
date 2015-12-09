using FICTFeed.Bussines.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        IList<User> GetList();

        OperationResult Update(User user);

        bool IsAvalibleForCreation(string mail);
    }
}
