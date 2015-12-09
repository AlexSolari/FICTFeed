using FICTFeed.Bussines.Models;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Map;
using FICTFeed.Framework.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.Validation
{  
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class UserMailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            var manager = Resolver.GetInstance<IUserManager>();

            ErrorMessage = "User with this mail already registered";
            
            return manager.IsAvalibleForCreation((string)obj);
        }
    }
}
