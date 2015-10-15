using FICTFeed.MVC.Models.ViewModels;
using FICTFeed.MVC.Models.ViewModels.User;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.User
{
    public class RegisterUserPageView : BasePageView
    {
        public UserCreateViewModel NewUser { get; set; }

        public RegisterUserPageView(HttpRequestBase request)
            : base(request)
        {
            NewUser = new UserCreateViewModel();
        }

        public RegisterUserPageView()
        {
            NewUser = new UserCreateViewModel();
        }
    }
}