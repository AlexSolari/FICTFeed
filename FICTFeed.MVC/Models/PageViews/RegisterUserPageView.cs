using FICTFeed.MVC.Models.ViewModels;

namespace FICTFeed.MVC.Models.PageViews
{
    public class RegisterUserPageView
    {
        public UserViewModel NewUser { get; set; }

        public RegisterUserPageView()
        {
            NewUser = new UserViewModel();
        }
    }
}