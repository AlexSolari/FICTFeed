using FICTFeed.Bussines;
using FICTFeed.Bussines.AdditionalData;
using FICTFeed.Framework.NHibernate;
using NHibernate;
using NHibernate.Criterion;

namespace FICTFeed.Framework.Users
{
    public class UserDataProvider : DataProvider<User>
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

        public User GetByRole(Roles role)
        {
            User result = null;
            Execute(session =>
            {
                var criteria = session.CreateCriteria(typeof(User));
                criteria.Add(Restrictions.Eq("Role", role));
                result = criteria.UniqueResult<User>();
            });
            return result;
        }
    }
}
