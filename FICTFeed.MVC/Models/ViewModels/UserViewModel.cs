using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.ViewModels
{
    public class UserViewModel
    {
        public virtual string Name { get; set; }

        public virtual string PasswordCrypted { get; set; }

        public virtual string Mail { get; set; }

        public UserViewModel() { }

        public UserViewModel(string name, string passwordRaw, string mail)
        {

        }
    }
}