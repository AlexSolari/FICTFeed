using FICTFeed.MVC.Models.ViewModels;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews
{
    public class LoginUserPageView : BasePageView
    {
        public UserLoginViewModel LoginData { get; set; }
        public bool Valid { get; set; }

        public LoginUserPageView(HttpRequestBase request)
            : base(request)
        {
            Valid = true;
            LoginData = new UserLoginViewModel();
        }

        public LoginUserPageView()
        {
            Valid = true;
            LoginData = new UserLoginViewModel();
        }
    }
}