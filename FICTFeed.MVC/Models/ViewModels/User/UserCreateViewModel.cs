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
        [CustomizebleStringLength(50, 3)]
        [СustomizebleRequired]
        public virtual string Name { get; set; }

        [CustomizebleStringLength(20, 5)]
        [СustomizebleRequired]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        [CustomizebleStringLength(20, 5)]
        [СustomizebleRequired]
        [DataType(DataType.Password)]
        [CustomizebleCompare("Password")]
        public virtual string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [UserMailValidation]
        [СustomizebleRequired]
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