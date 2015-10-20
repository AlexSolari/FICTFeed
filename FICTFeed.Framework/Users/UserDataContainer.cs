using FICTFeed.Bussines;
using FICTFeed.Bussines.AdditionalData;
using FICTFeed.Framework.Strings;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FICTFeed.Framework.Users
{
    public class UserDataContainer
    {
        IUserManager Manager;
        
        HttpRequestBase Request;
        
        public bool IsAuthorized
        {
            get
            {
                return Request.Cookies.AllKeys.Contains(CookiesNames.LoginCookie);
            }
            private set { }
        }

        public User CurrentUser
        {
            get
            {
                if (!IsAuthorized)
                    return null;

                return Manager.GetById(Request.Cookies[CookiesNames.LoginCookie].Value);
            }
            private set { }
        }

        public bool IsInRole(Roles role)
        {
            return (Guard.HaveEnoughRights(CurrentUser, role));
        }

        public UserDataContainer(HttpRequestBase request)
        {
            //TODO: Remove "request" like parametr from all project using HttpContext.Current.Request.RequestContext.HttpContext.Request instead;
            //var re = HttpContext.Current.Request.RequestContext.HttpContext.Request;
            this.Request = request;
            this.Manager = FICTFeed.DependecyResolver.Resolver.GetInstance<IUserManager>();
        }
    }
}
