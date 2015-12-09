using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.Extensions
{
    public class StringExtensions
    {
        public static string FormatWith(this string value, params object[] args)
        {
            return String.Format(value, args);
        }
    }
}
