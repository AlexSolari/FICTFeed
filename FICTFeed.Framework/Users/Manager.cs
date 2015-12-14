using FICTFeed.Bussines.Models;
using FICTFeed.Framework.Extensions;
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
using System.Net.Mail;
using System.Web.UI;
using System.IO;
using System.Net.Mime;

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
            if (String.IsNullOrWhiteSpace(mail))
                return true;

            var result = true;

            result = result && (provider.GetByMail(mail) == null);

            return result;
        }


        public void RestorePassword(string mail)
        {
            var user = provider.GetByMail(mail);

            if (user == null)
                return;

            using (var client = new SmtpClient())
            {
                var token = Resolver.GetSingleton<Encryptor>().GenerateToken(user);
                var host = System.Web.HttpContext.Current.Request.Url.Authority;
                var subject = Resources.ResourceAccessor
                    .Instance.Get("ForgotPasswordPage");
                var style = Resources.ResourceAccessor
                    .Instance.Get("ForgotMailTemplateStyle");
                var body = Resources.ResourceAccessor
                    .Instance.Get("ForgotMailTemplate")
                    .FormatWith(user.Name, host, user.Id, token);

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("fict.feed@gmail.com");
                msg.To.Add(mail);
                msg.Subject = subject;
                msg.IsBodyHtml = true;
                msg.Body = style + body;
                ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                msg.AlternateViews.Add(alternate);
                msg.Priority = MailPriority.High;

                client.Send(msg);
            }

        }
    }
}
