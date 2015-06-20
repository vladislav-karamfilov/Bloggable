namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Bloggable.Data.Models;
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Web.Areas.Administration.Controllers.Base;
    using Bloggable.Web.Models.Administration.Comments.ViewModels;

    using Kendo.Mvc.UI;

    public class CommentsController : KendoGridAdministrationController<Comment, CommentGridViewModel>
    {
        private readonly IDeletableEntityAdministrationService<Comment> administrationService;

        private int? postId;

        public CommentsController(IDeletableEntityAdministrationService<Comment> administrationService)
            : base(administrationService)
        {
            this.administrationService = administrationService;
        }

        [HttpPost]
        public ActionResult ReadComments([DataSourceRequest]DataSourceRequest request, int? postId)
        {
            this.postId = postId;
            return this.Read(request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, CommentGridViewModel model)
        {
            this.DestroyEntity(model.Id);
            return this.GridOperation(request, model);
        }

        protected override IEnumerable<CommentGridViewModel> GetData()
        {
            return this.administrationService.ReadWithDeleted().Where(c => c.PostId == this.postId).Project().To<CommentGridViewModel>();
        }
    }
}