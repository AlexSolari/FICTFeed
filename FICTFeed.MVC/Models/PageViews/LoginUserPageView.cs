using FICTFeed.MVC.Models.ViewModels;

namespace FICTFeed.MVC.Models.PageViews
{
    public class LoginUserPageView
    {
        public UserLoginViewModel LoginData { get; set; }
        public bool Valid { get; set; }

        public LoginUserPageView()
        {
            Valid = true;
            LoginData = new UserLoginViewModel();
        }
    }
}