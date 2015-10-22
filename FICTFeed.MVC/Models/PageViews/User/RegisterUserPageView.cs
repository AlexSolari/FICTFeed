using FICTFeed.MVC.Models.ViewModels;
using FICTFeed.MVC.Models.ViewModels.User;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.User
{
    public class RegisterUserPageView : BasePageView
    {
        public UserCreateViewModel NewUser { get; set; }

        public RegisterUserPageView()
            : base()
        {
            NewUser = new UserCreateViewModel();
        }
    }
}