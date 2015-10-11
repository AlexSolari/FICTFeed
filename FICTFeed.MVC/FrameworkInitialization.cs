using FICTFeed.DependecyResolver;
using FICTFeed.Framework;

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