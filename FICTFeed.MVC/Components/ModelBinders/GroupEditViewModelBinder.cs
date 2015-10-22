using FICTFeed.MVC.Models.ViewModels.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FICTFeed.MVC.Components.ModelBinders
{
    public class GroupEditViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string id = controllerContext.HttpContext.Request.Form.Get("item.Id");
            string name = controllerContext.HttpContext.Request.Form.Get("item.Name");

            var model = new GroupEditViewModel(name);
            model.Id = Guid.Parse(id);
            return model;
        }
    }
}