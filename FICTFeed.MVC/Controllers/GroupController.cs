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
        public ActionResult Shedule(string id)
        {
            var group = manager.GetById(id);
            var shedule = group.Shedule.DeserializeAs<Shedule>();

            return View(shedule);
        }

        [HttpPost]
        public ActionResult Shedule(Shedule shedule)
        {
            return View(shedule);
        }
    }
}