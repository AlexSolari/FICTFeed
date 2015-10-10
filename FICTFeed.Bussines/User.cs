using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Bussines
{
    class User : Entity
    {
        public virtual string Name { get; set; }

        public virtual string PasswordCrypted { get; set; }

        public virtual string Mail { get; set; }
    }
}
