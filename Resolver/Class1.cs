using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependecyResolver
{
    public static class Resolver
    {
        static Dictionary<Type, Type> typeDependencies = new Dictionary<Type, Type>();

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
    }
}
