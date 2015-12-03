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
using FICTFeed.MVC.Models.PageViews.User;
using FICTFeed.MVC.Models.ViewModels.Comments;
using FICTFeed.Framework.Extensions;
using System.Xml.Linq;
using System.Xml;
using FICTFeed.Framework.Shedule;

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
            Resolver.RegisterType<Comment, Comment>();
            Resolver.RegisterType<Group, Group>();
            Resolver.RegisterType<NewsItem, NewsItem>();
            Resolver.RegisterType<NewsItemViewModel, NewsItemViewModel>();
            Resolver.RegisterType<UserEditViewModel, UserEditViewModel>();
            Resolver.RegisterType<GroupEditViewModel, GroupEditViewModel>();
            Resolver.RegisterType<CommentCreateModel, CommentCreateModel>();
            Resolver.RegisterType<CommentViewModel, CommentViewModel>();
            Resolver.RegisterType<IUserManager, UserManager>();
            Resolver.RegisterType<INewsManager, NewsManager>();
            Resolver.RegisterType<IGroupsManager, GroupsManager>();
            Resolver.RegisterType<ICommentsManager, CommentsManager>();
        }

        static void RegisterSingletons()
        {
            Resolver.RegisterSingleton(new Encryptor());
        }

        static void SetupMappings()
        {
            Mapper.AddMapping<User, UserCreateViewModel>((result, source) =>
            {
                result.PasswordCrypted = Resolver.GetSingleton<Encryptor>().CryptPassword(source.Password);

                return result;
            });

            Mapper.AddMapping<Group, GroupCreateViewModel>((result, source) =>
            {
                result.CanBeDeleted = true;
                result.Schedule = new XmlDocument();
                result.Schedule.LoadXml(source.GroupShedule.Serialize());

                return result;
            });

            Mapper.AddMapping<GroupEditViewModel, Group>((result, source) =>
            {
                result.GroupShedule = source.Schedule.DeserializeAs<Shedule>();

                return result;
            });

            Mapper.AddMapping<Group, GroupEditViewModel>((result, source) =>
            {
                result.CanBeDeleted = true;
                result.Schedule = new XmlDocument();
                result.Schedule.LoadXml(source.GroupShedule.Serialize());

                return result;
            });

            Mapper.AddMapping<CommentViewModel, Comment>((result, source) =>
            {
                result.AuthorName = Resolver.GetInstance<IUserManager>().GetById(source.AuthorId.ToString()).Name;
                result.PostingDateString = source.PostingDate.ToShortDateString() + " " + source.PostingDate.ToShortTimeString();

                return result;
            });
        }

        static void RegisterBinders()
        {
            ModelBinders.Binders.Add(typeof(UserEditViewModel), new UserEditViewModelBinder());
            ModelBinders.Binders.Add(typeof(RegisterUserPageView), new RegisterUserPageViewBinder());
        }
    }
}