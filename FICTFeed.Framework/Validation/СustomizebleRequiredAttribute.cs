using FICTFeed.Resources;
using FICTFeed.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework.Validation
{
    public class СustomizebleRequiredAttribute : RequiredAttribute
    {
        public СustomizebleRequiredAttribute([CallerMemberName] string PropertyResourceName = null)
            : base()
        {
            var propName = ResourceAccessor.Instance.Get(PropertyResourceName);
            ErrorMessage =
                ResourceAccessor.Instance.Get("CustomizebleRequiredErrorMessage")
                .FormatWith(propName);
        }
    }
}
