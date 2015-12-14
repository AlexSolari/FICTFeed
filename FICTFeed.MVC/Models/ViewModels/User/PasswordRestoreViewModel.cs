using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.ViewModels.User
{
    public class PasswordRestoreViewModel
    {
        [CustomizebleStringLength(20, 5)]
        [СustomizebleRequired]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        [CustomizebleStringLength(20, 5)]
        [СustomizebleRequired]
        [DataType(DataType.Password)]
        [CustomizebleCompare("Password")]
        public virtual string ConfirmPassword { get; set; }
    }
}