﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.Validation
{
    public static class Guard
    {
        public static void ThrowIfNegative<T>(T value, string message, string paramName)
            where T : IComparable<T>
        {
            ThrowIfLessThan(value, default(T), message, paramName);
        }

        public static void ThrowIfLessThan<T>(T value, T minValue, string message, string paramName)
            where T : IComparable<T>
        {
            if (value.CompareTo(minValue) < 0)
                throw new ArgumentOutOfRangeException(paramName, message);
        }

        public static void ThrowIfNull(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Value cannot be null.", (Exception)null);
        }

        public static void ThrowIfNullOrContainsNull(IEnumerable collection, string paramName)
        {
            ThrowIfNull(collection);
            if (collection.Cast<object>().Contains(null))
                throw new ArgumentNullException(paramName);
        }

        public static void ThrowIfEmptyString(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("String cannot be null or empty.");
        }

        public static void ThrowIfEmpty<T>(IEnumerable<T> collection, string paramName, string message)
        {
            if (collection == null)
                throw new ArgumentNullException(paramName, message);

            if (!collection.Any())
                throw new ArgumentException(message, paramName);
        }

        public static void ThrowIfLonger(string str, int maxLength, string paramName)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > maxLength)
                throw new ArgumentOutOfRangeException(paramName, String.Format("{0} cannot be longer than {1} characters.", paramName, maxLength));
        }

        public static void ThrowIfNotEqual<T>(T value1, T value2, string message)
        {
            if (!EqualityComparer<T>.Default.Equals(value1, value2))
                throw new ArgumentException(message);
        }

        public static void ThrowIfEqual<T>(T value1, T value2, string message)
        {
            if (EqualityComparer<T>.Default.Equals(value1, value2))
                throw new ArgumentException(message);
        }

        public static void ThrowIfEmptyGuid(Guid guid, string message)
        {
            if (guid == Guid.Empty)
                throw new ArgumentException(message);
        }
    }
}
