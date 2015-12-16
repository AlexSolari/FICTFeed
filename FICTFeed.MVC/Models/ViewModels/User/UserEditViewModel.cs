using FICTFeed.Bussines.AdditionalData;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Groups;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.ViewModels.User
{
    public class UserEditViewModel
    {
        public virtual Guid Id { get; set; }

        [UIHint("GroupsDropdown")]
        public virtual Guid GroupId { get; set; }

        public virtual string Name { get; set; }

        public virtual string Mail { get; set; }

        [UIHint("EditRoles")]
        public virtual Roles Role { get; set; }
        
        public UserEditViewModel() { }

        public UserEditViewModel(string name, string mail, Roles role = Roles.User)
        {
            Name = name;
            Mail = mail;
            Role = role;
            GroupId = Resolver.GetInstance<IGroupsManager>().GetByName("Global").Id;
        }
    }
}