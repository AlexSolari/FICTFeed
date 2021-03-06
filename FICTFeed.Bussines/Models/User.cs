﻿using FICTFeed.Bussines.AdditionalData;
using System;
namespace FICTFeed.Bussines.Models
{
    public class User : Entity
    {
        public virtual string Name { get; set; }

        public virtual string PasswordCrypted { get; set; }

        public virtual string Mail { get; set; }

        public virtual bool Online { get; set; }

        public virtual Roles Role { get; set; }

        public virtual Guid GroupId { get; set; } 
    }
}
