using FICTFeed.Bussines.Models;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Strings;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FICTFeed.Framework.Users
{
    public class UserManager : IUserManager
    {
        protected UserDataProvider provider = new UserDataProvider();

        void CheckNullValues(User user)
        {
            Guard.ThrowIfEmptyString(user.Mail);
            Guard.ThrowIfEmptyString(user.Name);
            Guard.ThrowIfEmptyGuid(user.Id);
            Guard.ThrowIfEmptyString(user.PasswordCrypted);
        }

        public User GetById(string id)
        {
            Guard.ThrowIfEmptyString(id);

            return provider.GetById(id);
        }

        public IList<User> GetList()
        {
            return provider.GetList();
        }

        public OperationResult Register(User user)
        {
            CheckNullValues(user);

            Guard.ThrowIfLessThan(user.Name.Length, 3);
            Guard.ThrowIfLonger(user.Name, 50);

            if (provider.GetByMail(user.Mail) != null)
                return OperationResult.AlreadyRegistered;

            this.Create(user);

            return OperationResult.Success;
        }

        public void Create(User user)
        {
            provider.Create(user);
        }

        public OperationResult Login(string mail, string passwordRaw)
        {
            var response = HttpContext.Current.Request.RequestContext.HttpContext.Response;
            var user = provider.GetByMail(mail);
            if (user == null)
                return OperationResult.UnregisteredUser;

            if (Resolver.GetSingleton<Encryptor>().CryptPassword(passwordRaw) != user.PasswordCrypted)
                return OperationResult.InvalidPassword;

            user.Online = true;
            provider.Update(user);
            response.Cookies.Add(new HttpCookie(CookiesNames.LoginCookie, user.Id.ToString()));

            return OperationResult.Success;
        }

        public OperationResult Logout()
        {
            var request = HttpContext.Current.Request.RequestContext.HttpContext.Request;
            if (request.Cookies[CookiesNames.LoginCookie] == null)
                return OperationResult.InvalidCookie;

            var user = provider.GetById(request.Cookies[CookiesNames.LoginCookie].Value);

            if (user == null)
                return OperationResult.UnregisteredUser;

            user.Online = false;
            provider.Update(user);

            return OperationResult.Success;
        }

        public OperationResult Update(User user)
        {
            provider.Update(user);
            return OperationResult.Success;
        }

        public bool IsAvalibleForCreation(string mail)
        {
            Guard.ThrowIfEmptyString(mail);

            var result = true;

            result = result && (provider.GetByMail(mail) == null);

            return result;
        }
    }
}
