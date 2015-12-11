using FICTFeed.Bussines;
using FICTFeed.DependecyResolver;
using FICTFeed.Framework.Map;
using FICTFeed.Framework.News;
using FICTFeed.MVC.Models.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FICTFeed.MVC.Controllers
{
    public class CommentsController : Controller
    {
        ICommentsManager manager;

        public CommentsController()
        {
            manager = Resolver.GetInstance<ICommentsManager>();
        }

        [HttpPost]
        public ActionResult Create(CommentCreateModel model)
        {
            if (String.IsNullOrWhiteSpace(model.Description))
                return null;

            var mappedModel = Mapper.Map<Comment, CommentCreateModel>(model);

            manager.Create(mappedModel);

            var result = Mapper.Map<CommentViewModel,Comment>(manager.GetById(mappedModel.Id.ToString()));

            return PartialView("CommentPartial", result);
        }
    }
}