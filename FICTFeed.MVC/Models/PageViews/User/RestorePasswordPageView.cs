using FICTFeed.MVC.Models.ViewModels;
using FICTFeed.MVC.Models.ViewModels.User;
using FICTFeed.Framework.Validation;
using System.Web;

namespace FICTFeed.MVC.Models.PageViews.User
{
    public class RestorePasswordPageView : BasePageView
    {
        public PasswordRestoreViewModel NewPass { get; set; }

        public string UserId { get; set; }

        public RestorePasswordPageView()
            : base()
        {
            NewPass = new PasswordRestoreViewModel();
        }

        public RestorePasswordPageView(string id)
            :this()
        {
            UserId = id;
        }
    }
}