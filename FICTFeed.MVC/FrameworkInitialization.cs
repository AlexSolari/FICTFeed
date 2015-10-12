using FICTFeed.Bussines;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework;
using FICTFeed.Framework.Map;
using FICTFeed.Framework.Users;
using FICTFeed.MVC.Models.ViewModels;

namespace FICTFeed.MVC
{
    public static class FrameworkInitializer
    {
        public static void Start()
        {
            MapTypes();
            RegisterSingletons();
            SetupMappings();         
        }

        static void MapTypes()
        {
            Resolver.RegisterType<User, User>();
            Resolver.RegisterType<UserManager, UserManager>();
        }

        static void RegisterSingletons()
        {
            Resolver.RegisterSingleton<Encryptor>(new Encryptor());
        }

        static void SetupMappings()
        {
            Mapper.AddMapping<User, UserViewModel>((result, source) =>
            {
                result.PasswordCrypted = Resolver.GetSingleton<Encryptor>().CryptPassword(source.Password);

                return result;
            });
        }
    }
}