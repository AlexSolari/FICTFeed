using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.Users
{
    public enum OperationResult
    {
        Success,
        AlreadyRegistered,
        UnregisteredUser,
        InvalidPassword,
        InvalidCookie
    }
}
