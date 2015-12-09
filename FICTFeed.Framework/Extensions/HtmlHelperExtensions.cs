using FICTFeed.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FICTFeed.Framework.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string ResourceString<T>(this HtmlHelper<T> val, string key)
        {
            return ResourceAccessor.Instance.Get(key);
        }
    }
}
