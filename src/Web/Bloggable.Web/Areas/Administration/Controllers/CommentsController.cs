namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Services.Common.Mapping.Contracts;
    using Bloggable.Web.Areas.Administration.Controllers.Base;

    using Kendo.Mvc.UI;

    using EntityModel = Bloggable.Data.Models.Comment;
    using ViewModel = Bloggable.Web.Models.Administration.Comments.ViewModels.CommentGridViewModel;

    public class CommentsController : KendoGridAdministrationController<EntityModel, ViewModel>
    {
        private readonly IDeletableEntityAdministrationService<EntityModel> administrationService;

        private int? postId;

        public CommentsController(
            IDeletableEntityAdministrationService<EntityModel> administrationService,
            IMappingService mappingService)
            : base(administrationService, mappingService)
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
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            this.DestroyEntity(model.Id);
            return this.GridOperation(request, model);
        }

        protected override IEnumerable<ViewModel> GetData()
        {
            var data = this.administrationService.ReadWithDeleted().Where(c => c.PostId == this.postId);
            return this.MappingService.MapCollection<ViewModel>(data);
        }
    }
}