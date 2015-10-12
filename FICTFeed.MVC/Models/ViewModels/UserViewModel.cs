using FICTFeed.Framework.Validation;
using System.ComponentModel.DataAnnotations;

namespace FICTFeed.MVC.Models.ViewModels
{
    public class UserViewModel
    {
        [StringLength(50, ErrorMessage = "Must be between 3 and 50 characters", MinimumLength = 3)]
        [Required]
        public virtual string Name { get; set; }

        [StringLength(20, ErrorMessage="Must be between 5 and 20 characters", MinimumLength=5)]
        [Required]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        [StringLength(20, ErrorMessage = "Must be between 5 and 20 characters", MinimumLength = 5)]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public virtual string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public virtual string Mail { get; set; }

        public UserViewModel() { }

        public UserViewModel(string name, string password, string confirmPassword, string mail)
        {
            Guard.ThrowIfEmptyString(name);
            Guard.ThrowIfEmptyString(password);
            Guard.ThrowIfEmptyString(confirmPassword);
            Guard.ThrowIfEmptyString(mail);

            Name = name;
            Password = password;
            ConfirmPassword = confirmPassword;
            Mail = mail;
        }
    }
}