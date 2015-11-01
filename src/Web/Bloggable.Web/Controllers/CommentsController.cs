namespace Bloggable.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    
    using Bloggable.Common.Constants;
    using Bloggable.Services.Common.Mapping.Contracts;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Models.Comments.InputModels;
    using Bloggable.Web.Models.Comments.ViewModels;

    using Microsoft.AspNet.Identity;

    using PagedList;

    public class CommentsController : BaseController
    {
        private readonly ICommentsDataService commentsData;
        private readonly IMappingService mappingService;

        public CommentsController(ICommentsDataService commentsData, IMappingService mappingService)
        {
            this.commentsData = commentsData;
            this.mappingService = mappingService;
        }

        public ActionResult Read(int id, int? page)
        {
            var currentPage = page > 0 ? page.Value : 1;

            var postComments = this.GetPostCommentsPage(id, currentPage, GlobalConstants.DefaultPageSize);

            var viewModel = new PostCommentsPageViewModel
            {
                PostId = id,
                Comments = postComments
            };
            return this.PartialView("_PostComments", viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCommentInputModel inputModel)
        {
            if (inputModel != null && this.ModelState.IsValid)
            {
                var authorId = this.User.Identity.GetUserId();
                this.commentsData.AddCommentForPost(inputModel.PostId, inputModel.Content, authorId);

                var postCommentsCount = this.commentsData.GetCountByPost(inputModel.PostId);
                var lastPage = (int)Math.Ceiling((double)postCommentsCount / GlobalConstants.DefaultPageSize);
                var commentsLastPage = this.GetPostCommentsPage(inputModel.PostId, lastPage, GlobalConstants.DefaultPageSize);

                var viewModel = new PostCommentsPageViewModel
                {
                    PostId = inputModel.PostId,
                    Comments = commentsLastPage
                };
                return this.PartialView("_PostComments", viewModel);
            }

            return this.JsonValidation();
        }

        [Authorize]
        public ActionResult Update(int id)
        {
            var comment = this.commentsData.GetById(id);
            if (comment == null || (comment.AuthorId != this.User.Identity.GetUserId() && !this.User.IsAdmin()))
            {
                return this.JsonError(
                    "There is no such comment or you don't have permissions to edit it...",
                    null,
                    null,
                    JsonRequestBehavior.AllowGet);
            }

            var viewModel = this.mappingService.Map<UpdateCommentInputModel>(comment);
            return this.PartialView("_UpdateComment", viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateCommentInputModel inputModel)
        {
            if (inputModel != null && this.ModelState.IsValid)
            {
                var authorId = this.commentsData.GetAuthorId(inputModel.Id) as string;
                if (string.IsNullOrWhiteSpace(authorId) || (authorId != this.User.Identity.GetUserId() && !this.User.IsAdmin()))
                {
                    return this.JsonError(
                        "There is no such comment or you don't have permissions to edit it...",
                        null,
                        null,
                        JsonRequestBehavior.AllowGet);
                }

                var comment = this.commentsData.UpdateComment(inputModel.Id, inputModel.Content);

                var viewModel = this.mappingService.Map<CommentViewModel>(comment);
                return this.PartialView("DisplayTemplates/CommentViewModel", viewModel);
            }

            return this.JsonValidation();
        }

        private IPagedList<CommentViewModel> GetPostCommentsPage(int postId, int page, int pageSize)
        {
            var comments = this.commentsData.GetByPost(postId).OrderBy(c => c.CreatedOn);

            var commentsPage = this.mappingService.MapCollection<CommentViewModel>(comments).ToPagedList(page, pageSize);

            return commentsPage;
        }
    }
}