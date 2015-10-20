using FICTFeed.Bussines;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace FICTFeed.Framework.NHibernate
{
    public class DataProvider<TEntity>
        where TEntity : Entity
    {
        SessionHelper sessionHelper = new SessionHelper();
        private ISession CreateSession()
        {
            if (!sessionHelper.Current.IsOpen)
                return sessionHelper.OpenSession();
            return sessionHelper.Current;
        }

        protected T Execute<T>(Func<ISession, T> func, string errorMessage = null)
        {
            try
            {
                using (var session = CreateSession())
                {
                    return func(session);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void Execute(Action<ISession> action, string errorMessage = null)
        {
            try
            {
                using (var session = CreateSession())
                {
                    action(session);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<TEntity> GetList(string orderBy = null)
        {
            return Execute(session =>
            {
                var criteria = session.CreateCriteria<TEntity>();
                if (!String.IsNullOrWhiteSpace(orderBy))
                    criteria = criteria.AddOrder(Order.Desc(orderBy));
                return criteria.List<TEntity>();
            });
        }

        public TEntity GetById(string id)
        {
            return Execute(session =>
            {
                return session.Get<TEntity>(Guid.Parse(id));
            });
        }

        public void Create(TEntity model)
        {
            Execute(session =>
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(model);
                    transaction.Commit();
                }
            });
        }

        public void Update(TEntity model)
        {
            Execute(session =>
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(model);
                    transaction.Commit();
                }
            });
        }

        //public async void UpdateAsync(TEntity model)
        //{
        //    await System.Threading.Tasks.Task.Run(() =>
        //    {
        //        Execute(session =>
        //        {
        //            using (var transaction = session.BeginTransaction())
        //            {
        //                session.Update(model);
        //                transaction.Commit();
        //            }
        //        });
        //    });
        //}

        public void Delete(TEntity model)
        {
            Execute(session =>
            {
                session.Delete(model);
                session.Flush();
            });
        }
    }
}