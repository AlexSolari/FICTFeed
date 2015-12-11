using FICTFeed.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FICTFeed.Framework.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string ResourceString<T>(this HtmlHelper<T> val, string key)
        {
            return ResourceAccessor.Instance.Get(key);
        }

        public static MvcHtmlString ResourceLabelFor<T, TValue>(this HtmlHelper<T> val, Expression<Func<T, TValue>> expression)
        {
            var proxyValue = val.LabelFor(expression).ToString();
            var groups = Regex.Match(proxyValue, "<[\\w\\s=\"]*>([\\w\\s-.,]*)<\\/[\\w\\s=\"]*>");
            var resourceName = groups.Groups[1].Value;
            var name = ResourceAccessor.Instance.Get(resourceName);
            var result = "<label>{0}</label>".FormatWith(name);
            return new MvcHtmlString(result);
        }
    }
}
