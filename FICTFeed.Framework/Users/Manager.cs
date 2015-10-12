using FICTFeed.Bussines;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.Users
{
    public class UserManager
    {
        UserDataProvider Provider = new UserDataProvider();
 
        public void Register(User user)
        {
            Guard.ThrowIfEmptyString(user.Mail);
            Guard.ThrowIfEmptyString(user.Name);
            Guard.ThrowIfEmptyGuid(user.Id);
            Guard.ThrowIfEmptyString(user.PasswordCrypted);

            Guard.ThrowIfLessThan(user.Name.Length, 3);
            Guard.ThrowIfLonger(user.Name, 50);

            if (Provider.GetByMail(user.Mail) != null)
                throw new ArgumentException("User with this mail already registered");

            Provider.Create(user);
        }
    }
}
