using FICTFeed.Bussines;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FICTFeed.Framework.Users
{
    public class UserManager
    {
        public enum OperationResult
        {
            Success,
            AlreadyRegistered,
            UnregisteredUser,
            InvalidPassword,
            InvalidCookie
        }

        UserDataProvider Provider = new UserDataProvider();

        void CheckNullValues(User user)
        {
            Guard.ThrowIfEmptyString(user.Mail);
            Guard.ThrowIfEmptyString(user.Name);
            Guard.ThrowIfEmptyGuid(user.Id);
            Guard.ThrowIfEmptyString(user.PasswordCrypted);
        }

        public OperationResult Register(User user)
        {
            CheckNullValues(user);

            Guard.ThrowIfLessThan(user.Name.Length, 3);
            Guard.ThrowIfLonger(user.Name, 50);

            if (Provider.GetByMail(user.Mail) != null)
                return OperationResult.AlreadyRegistered;

            Provider.Create(user);

            return OperationResult.Success;
        }

        public OperationResult Login(string mail, string passwordRaw, HttpRequestBase request)
        {
            var user = Provider.GetByMail(mail);
            if (user == null)
                return OperationResult.UnregisteredUser;

            if (Resolver.GetSingleton<Encryptor>().CryptPassword(passwordRaw) != user.PasswordCrypted)
                return OperationResult.InvalidPassword;

            user.Online = true;
            Provider.Update(user);
            request.Cookies.Add(new HttpCookie("FICTFeed.LoginCookie", user.Id.ToString()));

            return OperationResult.Success;
        }

        public OperationResult Logout(HttpRequestBase request)
        {
            var user = Provider.GetById(request.Cookies["FICTFeed.LoginCookie"].Value);

            if (user == null)
                return OperationResult.InvalidCookie;

            user.Online = false;
            Provider.Update(user);
            request.Cookies.Remove("FICTFeed.LoginCookie");

            return OperationResult.Success;
        }
    }
}
