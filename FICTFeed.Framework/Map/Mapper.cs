﻿using FICTFeed.DependecyResolver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.Map
{
    public class Mapper
    {
        public static Dictionary<Type, Func<object, object, object>> CustomMappings = new Dictionary<Type, Func<object, object, object>>();

        public static TDestination Map<TDestination,TSource>(TSource source)
        {
            var result = Resolver.GetInstance<TDestination>();

            foreach (var fieldR in typeof(TDestination).GetProperties())
            {
                foreach (var fieldS in typeof(TSource).GetProperties())
                {
                    if (fieldR.Name == fieldS.Name)
                    {
                        fieldR.SetValue(result, fieldS.GetValue(source));
                    }
                }
            }

            if (CustomMappings.ContainsKey(typeof(TSource)))
                result = (TDestination)CustomMappings[typeof(TSource)](result, source);

            return result;
        }

        public static TDestination MapAndMerge<TDestination, TSource>(TSource source, TDestination result)
        {
            foreach (var fieldR in typeof(TDestination).GetProperties())
            {
                foreach (var fieldS in typeof(TSource).GetProperties())
                {
                    if (fieldR.Name == fieldS.Name)
                    {
                        fieldR.SetValue(result, fieldS.GetValue(source));
                    }
                }
            }

            if (CustomMappings.ContainsKey(typeof(TSource)))
                result = (TDestination)CustomMappings[typeof(TSource)](result, source);

            return result;
        }

        public static TDestination MapAs<TDestination>(object source)
        {
            var result = Resolver.GetInstance<TDestination>();

            foreach (var fieldR in typeof(TDestination).GetProperties())
            {
                foreach (var fieldS in source.GetType().GetProperties())
                {
                    if (fieldR.Name == fieldS.Name)
                    {
                        fieldR.SetValue(result, fieldS.GetValue(source));
                    }
                }
            }

            if (CustomMappings.ContainsKey(source.GetType()))
                result = (TDestination)CustomMappings[source.GetType()](result, source);

            return result;
        }

        public static IEnumerable<TDestination> Map<TDestination, TSource>(IEnumerable<TSource> source)
        {
            var result = new List<TDestination>();
            foreach (var item in source)
            {
                result.Add(Map<TDestination, TSource>(item));
            }
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
