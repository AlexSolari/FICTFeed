using FICTFeed.Bussines.AdditionalData;
using FICTFeed.MVC.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FICTFeed.MVC.Components.ModelBinders
{
    public class UserEditViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string id = controllerContext.HttpContext.Request.Form.Get("item.Id");
            string role = controllerContext.HttpContext.Request.Form.Get("item.Role");
            string mail = controllerContext.HttpContext.Request.Form.Get("item.Mail");
            string name = controllerContext.HttpContext.Request.Form.Get("item.Name");
            Roles userRole = (Roles)Enum.Parse(typeof(FICTFeed.Bussines.AdditionalData.Roles), role);
            
            var model = new UserEditViewModel(name, mail, userRole);
            model.Id = Guid.Parse(id);
            return model;
        }
    }
}