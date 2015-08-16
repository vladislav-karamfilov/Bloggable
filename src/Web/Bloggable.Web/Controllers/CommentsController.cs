namespace Bloggable.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Bloggable.Common.Constants;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Models.Comments.InputModels;
    using Bloggable.Web.Models.Comments.ViewModels;
    
    using Microsoft.AspNet.Identity;

    using PagedList;

    [Authorize]
    public class CommentsController : BaseController
    {
        private readonly ICommentsDataService commentsData;

        public CommentsController(ICommentsDataService commentsData)
        {
            this.commentsData = commentsData;
        }

        [HttpGet]
        public ActionResult Read(int id, int? page)
        {
            var currentPage = page > 0 ? page.Value : 1;

            var postComments = this.commentsData
                .ByPost(id)
                .OrderByDescending(c => c.CreatedOn)
                .Project()
                .To<CommentViewModel>()
                .ToPagedList(currentPage, GlobalConstants.DefaultPageSize);

            var model = new PostCommentsPageViewModel
            {
                PostId = id,
                Comments = postComments
            };

            return this.PartialView("_PostComments", model);
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

        [HttpGet]
        public ActionResult Update(int id)
        {
            throw new NotImplementedException("Return partial view for comment editing.");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateCommentInputModel inputModel)
        {
            if (inputModel != null && this.ModelState.IsValid)
            {
                var authorId = this.commentsData.GetAuthorId(inputModel.CommentId) as string;
                if (authorId == this.User.Identity.GetUserId())
                {
                    this.commentsData.UpdateComment(inputModel.CommentId, inputModel.Content);

                    // TODO: Extract Controller extension method JsonSuccess
                    return this.Json(new { Message = "success" });
                }

                // TODO: Extract Controller extension method JsonError
                return this.Json(new { Message = "error" });
            }

            // TODO: Extract Controller extension method JsonError
            return this.Json(new { Message = "error" });
        }
    }
}