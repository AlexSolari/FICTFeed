using FICTFeed.Bussines.AdditionalData;
using FICTFeed.Bussines.Models;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Groups;
using FICTFeed.Framework.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;

namespace FICTFeed.MVC.Models.ViewModels.User
{
    public class UserCreateViewModel
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

        protected readonly List<Group> groups;

        public IEnumerable<System.Web.Mvc.SelectListItem> Groups
        {
            get
            {
                return new System.Web.Mvc.SelectList(groups, "Id", "Name");
            }
        }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public virtual System.Guid GroupId { get; set; }

        protected virtual Roles Role { get; set; }

        public UserCreateViewModel()
        {
            var manager = Resolver.GetInstance<IGroupsManager>();
            groups = (List<Group>)manager.GetList();
        }

        public UserCreateViewModel(string name, string password, string confirmPassword, string mail)
        {
            Guard.ThrowIfEmptyString(name);
            Guard.ThrowIfEmptyString(password);
            Guard.ThrowIfEmptyString(confirmPassword);
            Guard.ThrowIfEmptyString(mail);

            var manager = Resolver.GetInstance<IGroupsManager>();
            groups = (List<Group>)manager.GetList();
            Name = name;
            Password = password;
            ConfirmPassword = confirmPassword;
            Mail = mail;
            Role = Roles.User;
        }
    }
}