using FICTFeed.Resources;
using FICTFeed.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace FICTFeed.Framework.Validation
{
    public class CustomizebleStringLengthAttribute : StringLengthAttribute
    {
        public CustomizebleStringLengthAttribute(int MaxLength, int MinLength, [CallerMemberName] string PropertyResourceName = null)
            : base(MaxLength)
        {
            MinimumLength = MinLength;
            var propName = ResourceAccessor.Instance.Get(PropertyResourceName);
            ErrorMessage =
                ResourceAccessor.Instance.Get("CustomizebleStringLengthErrorMessage")
                .FormatWith(propName, MaxLength, MinimumLength);
        }
    }
}
