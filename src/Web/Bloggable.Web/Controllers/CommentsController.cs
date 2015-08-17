namespace Bloggable.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bloggable.Common.Constants;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Models.Comments.InputModels;
    using Bloggable.Web.Models.Comments.ViewModels;

    using Microsoft.AspNet.Identity;

    using PagedList;

    public class CommentsController : BaseController
    {
        private readonly ICommentsDataService commentsData;

        public CommentsController(ICommentsDataService commentsData)
        {
            this.commentsData = commentsData;
        }
        
        public ActionResult Read(int id, int? page)
        {
            var currentPage = page > 0 ? page.Value : 1;

            var postComments = this.commentsData
                .ByPost(id)
                .OrderByDescending(c => c.CreatedOn)
                .Project()
                .To<CommentViewModel>()
                .ToPagedList(currentPage, GlobalConstants.DefaultPageSize);

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
                var comment = this.commentsData.AddCommentForPost(inputModel.PostId, inputModel.Content, authorId);

                var viewModel = Mapper.Map<CommentViewModel>(comment);
                return this.PartialView("DisplayTemplates/CommentViewModel", viewModel);
            }
            
            return this.JsonValidation();
        }

        [Authorize]
        public ActionResult Update(int id)
        {
            var comment = this.commentsData.GetById(id);
            if (comment == null)
            {
                return this.JsonError("There is no such comment...");
            }

            if (comment.AuthorId != this.User.Identity.GetUserId())
            {
                return this.JsonError("Cannot edit comment that is not yours.");
            }

            var viewModel = Mapper.Map<UpdateCommentInputModel>(comment);
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
                if (authorId == this.User.Identity.GetUserId())
                {
                    var comment = this.commentsData.UpdateComment(inputModel.Id, inputModel.Content);

                    var viewModel = Mapper.Map<CommentViewModel>(comment);
                    return this.PartialView("DisplayTemplates/CommentViewModel", viewModel);
                }
                
                return this.JsonError("Cannot edit comment that is not yours.");
            }

            return this.JsonValidation();
        }
    }
}