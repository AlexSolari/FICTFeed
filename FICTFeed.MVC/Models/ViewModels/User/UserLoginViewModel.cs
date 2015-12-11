using FICTFeed.Framework.Validation;
using System.ComponentModel.DataAnnotations;

namespace FICTFeed.MVC.Models.ViewModels.User
{
    public class UserLoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [СustomizebleRequired]
        public virtual string Mail { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [СustomizebleRequired]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        public UserLoginViewModel() { }
    }
}