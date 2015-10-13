using FICTFeed.MVC.Models.ViewModels;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews
{
    public class RegisterUserPageView : BasePageView
    {
        public UserViewModel NewUser { get; set; }

        public RegisterUserPageView(HttpRequestBase request)
            : base(request)
        {
            NewUser = new UserViewModel();
        }

        public RegisterUserPageView()
        {
            NewUser = new UserViewModel();
        }
    }
}