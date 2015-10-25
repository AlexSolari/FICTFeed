using FICTFeed.MVC.Models.PageViews.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FICTFeed.MVC.Components.ModelBinders
{
    public class RegisterUserPageViewBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = base.BindModel(controllerContext, bindingContext);

            ((RegisterUserPageView)model).NewUser.GroupId = Guid.Parse(controllerContext.HttpContext.Request.Form.Get("NewUser.GroupId").Split(',').Last());

            return model;
        }
    }
}