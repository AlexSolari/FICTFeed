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
using Rotativa;

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
            return new ActionAsPdf("SchedulePDF", new {id = id});
        }

        public ActionResult SchedulePDF(string id)
        {
            var group = manager.GetById(id);
            var shedule = group.Schedule.DeserializeAs<Schedule>();
            return View(shedule);
        }

    }
}