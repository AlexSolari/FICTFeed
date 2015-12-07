using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace FICTFeed.Framework.Extensions
{
    public static class ControllerExtensions
    {
        public static byte[] ViewAsBytes(this Controller controller, string viewName, string layout = "_Layout", object model = null)
        {
            ViewEngineResult result = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, layout);

            string viewResult = "";
            var viewData = controller.ViewData;
            viewData.Model = model;
            TempDataDictionary tempData = new TempDataDictionary();
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (HtmlTextWriter output = new HtmlTextWriter(sw))
                {
                    ViewContext viewContext = new ViewContext(controller.ControllerContext,
                        result.View, viewData, tempData, output);
                    result.View.Render(viewContext, output);
                }
                viewResult = sb.ToString();
            }
            viewResult = viewResult.Replace("\r\n", string.Empty);
            return Encoding.UTF8.GetBytes(viewResult);
        }

    }
}
