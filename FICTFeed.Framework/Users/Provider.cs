using FICTFeed.Bussines;
using FICTFeed.Framework.NHibernate;
using NHibernate;
using NHibernate.Criterion;

namespace FICTFeed.Framework.Users
{
    class UserDataProvider : DataProvider<User>
    {
        public User GetByMail(string mail)
        {
            return Execute(session =>
            {
                var criteria = session.CreateCriteria(typeof(User));
                criteria.Add(Restrictions.Eq("Email", mail));
                return criteria.UniqueResult<User>();
            });
        }
    }
}
