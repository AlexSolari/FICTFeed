using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFee.DependecyResolver
{
    public static class Resolver
    {
        static Dictionary<Type, Type> typeDependencies = new Dictionary<Type, Type>();
        static Dictionary<Type, object> singletons = new Dictionary<Type, object>();

        #region Types

        public static Type Resolve<T>()
        {
            return typeDependencies[typeof(T)];
        }

        public static void RegisterType<T,I>()
        {
            typeDependencies.Add(typeof(T), typeof(I));
        }

        public static T GetInstance<T>()
        {
            return (T)Activator.CreateInstance(Resolve<T>());
        }

        #endregion
        #region Singletons
        
        public static void RegisterSingleton<T>(T obj)
        {
            singletons.Add(typeof(T), obj);
        }

        public static T GetSingleton<T>()
        {
            return (T)singletons[typeof(T)];
        }

        #endregion
    }
}
