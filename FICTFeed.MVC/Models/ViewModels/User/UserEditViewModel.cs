using FICTFeed.Bussines.AdditionalData;
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

        public virtual string Name { get; set; }

        public virtual string Mail { get; set; }

        [UIHint("EditRoles")]
        public virtual Roles Role { get; set; }
        
        public UserEditViewModel() { }

        public UserEditViewModel(string name, string mail, Roles role)
        {
            Guard.ThrowIfEmptyString(name);
            Guard.ThrowIfEmptyString(mail);

            Name = name;
            Mail = mail;
            Role = Roles.User;
        }
    }
}