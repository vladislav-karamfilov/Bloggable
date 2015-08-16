namespace Bloggable.Web.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Models.Comments.InputModels;

    using Microsoft.AspNet.Identity;

    public class CommentsController : BaseController
    {
        private readonly ICommentsDataService commentsData;

        public CommentsController(ICommentsDataService commentsData)
        {
            this.commentsData = commentsData;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCommentInputModel inputModel)
        {
            if (inputModel != null && this.ModelState.IsValid)
            {
                var authorId = this.User.Identity.GetUserId();

                this.commentsData.AddCommentForPost(inputModel.PostId, inputModel.Content, authorId);
                
                // TODO: Extract Controller extension method JsonSuccess
                return this.Json(new { Message = "success" });
            }

            // TODO: Extract Controller extension method JsonError
            return this.Json(new { Message = "error" });
        }
    }
}