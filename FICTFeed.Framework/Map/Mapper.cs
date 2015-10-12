using FICTFeed.DependecyResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.Map
{
    public class Mapper
    {
        public static Dictionary<Type, Func<object, object, object>> CustomMappings = new Dictionary<Type, Func<object, object, object>>();

        public static T Map<T,I>(I source)
        {
            var result = Resolver.GetInstance<T>();

            foreach (var fieldR in typeof(T).GetProperties())
            {
                foreach (var fieldS in typeof(I).GetProperties())
                {
                    if (fieldR.Name == fieldS.Name)
                    {
                        fieldR.SetValue(result, fieldS.GetValue(source));
                    }
                }
            }

            if (CustomMappings.ContainsKey(typeof(I)))
                result = (T)CustomMappings[typeof(I)](result, source);

            return result;
        }

        public static void AddMapping<T,I>(Func<T, I, T> mapping)
        {
            if (CustomMappings.ContainsKey(typeof(I)))
                throw new ArgumentException("Mapping for this type already created");

            var tmp = Wrapper(mapping);

            CustomMappings.Add(typeof(I), tmp);
        }

        static Func<object, object, object> Wrapper<T,I>(Func<T, I, T> mapping)
        {
            return (r, s) => 
            { 
                var R = (T)r;
                var S = (I)s;
                return mapping(R, S);
            };
        }
    }
}
