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
            User result = null;
            Execute(session =>
            {
                var criteria = session.CreateCriteria(typeof(User));
                criteria.Add(Restrictions.Eq("Mail", mail));
                result = criteria.UniqueResult<User>();
            });
            return result;
        }
    }
}
