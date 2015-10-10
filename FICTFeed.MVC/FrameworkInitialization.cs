using FICTFeed.DependecyResolver;
using FICTFeed.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC
{
    public static class FrameworkInitializer
    {
        public static void Start()
        {
            Resolver.RegisterSingleton<Encryptor>(new Encryptor());
        }
    }
}