using FICTFeed.Bussines;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework;
using FICTFeed.Framework.Map;
using FICTFeed.Framework.News;
using FICTFeed.Framework.Users;
using FICTFeed.MVC.Models.ViewModels;
using FICTFeed.MVC.Models.ViewModels.News;
using FICTFeed.MVC.Models.ViewModels.User;
using FICTFeed.Framework.Groups;
using FICTFeed.MVC.Models.ViewModels.Groups;
using FICTFeed.Bussines.Models;
using System.Web.Mvc;
using FICTFeed.MVC.Components.ModelBinders;

namespace FICTFeed.MVC
{
    public static class FrameworkInitializer
    {
        public static void Start()
        {
            RegisterBinders();
            MapTypes();
            RegisterSingletons();
            SetupMappings();         
        }

        static void MapTypes()
        {
            Resolver.RegisterType<User, User>();
            Resolver.RegisterType<NewsItem, NewsItem>();
            Resolver.RegisterType<NewsItemViewModel, NewsItemViewModel>();
            Resolver.RegisterType<UserEditViewModel, UserEditViewModel>();
            Resolver.RegisterType<Group, Group>();
            Resolver.RegisterType<GroupEditViewModel, GroupEditViewModel>();
            Resolver.RegisterType<IUserManager, UserManager>();
            Resolver.RegisterType<INewsManager, NewsManager>();
            Resolver.RegisterType<IGroupsManager, GroupsManager>();
        }

        static void RegisterSingletons()
        {
            Resolver.RegisterSingleton<Encryptor>(new Encryptor());
        }

        static void SetupMappings()
        {
            Mapper.AddMapping<User, UserCreateViewModel>((result, source) =>
            {
                result.PasswordCrypted = Resolver.GetSingleton<Encryptor>().CryptPassword(source.Password);

                return result;
            });
        }

        static void RegisterBinders()
        {
            ModelBinders.Binders.Add(typeof(UserEditViewModel), new UserEditViewModelBinder());
            ModelBinders.Binders.Add(typeof(GroupEditViewModel), new GroupEditViewModelBinder());
        }
    }
}