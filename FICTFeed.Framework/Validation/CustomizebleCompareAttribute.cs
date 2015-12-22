using FICTFeed.Resources;
using FICTFeed.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FICTFeed.Framework.Validation
{
    public class CustomizebleCompareAttribute : CompareAttribute
    {
        public CustomizebleCompareAttribute(string otherProperty, [CallerMemberName] string PropertyResourceName = null)
            : base(otherProperty)
        {
            var firstPropName = ResourceAccessor.Instance.Get(otherProperty);
            var secondPropName = ResourceAccessor.Instance.Get(PropertyResourceName);

            ErrorMessage = 
                ResourceAccessor.Instance.Get("CustomizebleCompareErrorMessage")
                .FormatWith(firstPropName, secondPropName);
        }
    }
}
