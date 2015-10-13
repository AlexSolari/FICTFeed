using FICTFeed.Bussines;
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
        UserManager Manager;
        
        HttpRequestBase Request;
        
        public bool IsAuthorized
        {
            get
            {
                return Request.Cookies.AllKeys.Contains(LoginCookie);
            }
            private set { }
        }

        public User CurrentUser
        {
            get
            {
                if (!IsAuthorized)
                    return null;

                return Manager.Provider.GetById(Request.Cookies[LoginCookie].Value);
            }
            private set { }
        }

        public UserDataContainer(HttpRequestBase request)
        {
            this.Request = request;
            this.Manager = new UserManager();
        }
    }
}
