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
            var shedule = group.Schedule.DeserializeAs<Schedule>();

            shedule.GetScheduleForToday();
            return File(this.ViewAsBytes("Schedule", null, shedule), "application/x-www-form-urlencoded", group.Name + ".html");
        }
    }
}