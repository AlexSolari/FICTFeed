using FICTFeed.MVC.Models.ViewModels;

namespace FICTFeed.MVC.Models.PageViews
{
    public class LoginUserPageView
    {
        public UserLoginViewModel LoginData { get; set; }

        public LoginUserPageView()
        {
            LoginData = new UserLoginViewModel();
        }
    }
}