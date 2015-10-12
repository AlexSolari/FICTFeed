using FICTFeed.Framework.Validation;
using System.ComponentModel.DataAnnotations;

namespace FICTFeed.MVC.Models.ViewModels
{
    public class UserLoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public virtual string Mail { get; set; }

        [StringLength(20, ErrorMessage="Must be between 5 and 20 characters", MinimumLength=5)]
        [Required]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        public UserLoginViewModel() { }
    }
}