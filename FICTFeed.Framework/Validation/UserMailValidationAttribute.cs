using FICTFeed.Bussines.Models;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Map;
using FICTFeed.Framework.Users;
using FICTFeed.Resources;
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

            ErrorMessage = ResourceAccessor.Instance.Get("AlreadyRegistered");
            
            return manager.IsAvalibleForCreation((string)obj);
        }
    }
}
