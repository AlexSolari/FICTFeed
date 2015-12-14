using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Groups;
using FICTFeed.Framework.Map;
using FICTFeed.Framework.Shedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FICTFeed.Framework.Extensions;
using RazorPDF.Legacy;
using System.IO;
using System.Xml;
using FICTFeed.Bussines.Models;
using RazorPDF.Legacy.Text.Xml;
using RazorPDF.Legacy.Text;
using RazorPDF.Legacy.Text.Pdf;

namespace FICTFeed.MVC.Controllers
{
    public class GroupController : Controller
    {
        IGroupsManager manager;

        public GroupController()
        {
            manager = Resolver.GetInstance<IGroupsManager>();
        }

        [HttpGet]
        public ActionResult Schedule(string id)
        {
            var group = manager.GetById(id);
            //var shedule = group.Schedule.DeserializeAs<Schedule>();

            //shedule.GetScheduleForToday();
            //return File(this.ViewAsBytes("Schedule", null, shedule), "application/pdf", group.Name + ".pdf");
            //return File(this.ViewAsBytes("Schedule", null, shedule), "application/x-www-form-urlencoded", group.Name + ".html");
            return ViewPdf(group.Schedule.DeserializeAs<Schedule>());
        }


        protected string RenderActionResultToString(ActionResult result)
        {
            // Create memory writer.
            var sb = new System.Text.StringBuilder();
            var memWriter = new System.IO.StringWriter(sb);

            // Create fake http context to render the view.
            var fakeResponse = new HttpResponse(memWriter);
            var fakeContext = new HttpContext(System.Web.HttpContext.Current.Request,
                fakeResponse);
            var fakeControllerContext = new ControllerContext(
                new HttpContextWrapper(fakeContext),
                this.ControllerContext.RouteData,
                this.ControllerContext.Controller);
            var oldContext = System.Web.HttpContext.Current;
            System.Web.HttpContext.Current = fakeContext;

            // Render the view.
            result.ExecuteResult(fakeControllerContext);

            // Restore old context.
            System.Web.HttpContext.Current = oldContext;

            // Flush memory and return output.
            memWriter.Flush();
            return sb.ToString();
        }

        protected ActionResult ViewPdf(object model)
        {
            // Create the iTextSharp document.
            Document doc = new Document();
            // Set the document to write to memory.
            MemoryStream memStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memStream);
            writer.CloseStream = false;
            doc.Open();

            // Render the view xml to a string, then parse that string into an XML dom.
            string xmltext = this.RenderActionResultToString(this.View(model));
            xmltext = "<div>" + xmltext + "</div>";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.InnerXml = xmltext.Trim();

            // Parse the XML into the iTextSharp document.
            ITextHandler textHandler = new ITextHandler(doc);
            textHandler.Parse(xmldoc);

            // Close and get the resulted binary data.
            //doc.Close();
            byte[] buf = new byte[memStream.Position];
            memStream.Position = 0;
            memStream.Read(buf, 0, buf.Length);

            // Send the binary data to the browser.
            return new BinaryContentResult(buf, "application/pdf");
        }

        public class BinaryContentResult : ActionResult
        {
            private string ContentType;
            private byte[] ContentBytes;

            public BinaryContentResult(byte[] contentBytes, string contentType)
            {
                this.ContentBytes = contentBytes;
                this.ContentType = contentType;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                var response = context.HttpContext.Response;
                response.Clear();
                response.Cache.SetCacheability(HttpCacheability.NoCache);
                response.ContentType = this.ContentType;

                var stream = new MemoryStream(this.ContentBytes);
                stream.WriteTo(response.OutputStream);
                stream.Dispose();
            }
        }
    }
}