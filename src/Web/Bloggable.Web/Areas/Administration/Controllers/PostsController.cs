namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper;

    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Web.Areas.Administration.Controllers.Base;
    using Bloggable.Web.Infrastructure.Extensions;

    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using EntityModel = Bloggable.Data.Models.Post;
    using ViewModel = Bloggable.Web.Models.Administration.Posts.ViewModels.PostGridViewModel;

    public class PostsController : KendoGridAdministrationController<EntityModel, ViewModel>
    {
        private readonly IDeletableEntityAdministrationService<EntityModel> administrationService;

        public PostsController(IDeletableEntityAdministrationService<EntityModel> administrationService)
            : base(administrationService)
        {
            this.administrationService = administrationService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View(new ViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "AuthorId, Id")]ViewModel model)
        {
            model.AuthorId = this.User.Identity.GetUserId();
            var entity = this.CreateEntity(model);

            if (entity != null)
            {
                return this.RedirectToAction(c => c.Index()).WithSuccessAlert("Successfully created post.");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            var entity = this.administrationService.Get(id);

            if (entity != null)
            {
                var model = Mapper.Map<ViewModel>(entity);
                return this.View(model);
            }

            return this.RedirectToAction(c => c.Index()).WithErrorAlert("Post not found.");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ViewModel model)
        {
            var updatedEntity = this.FindAndUpdateEntity(model.Id, model);

            if (updatedEntity != null)
            {
                return this.RedirectToAction(c => c.Index()).WithSuccessAlert("Post updated successfully.");
            }

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            this.DestroyEntity(model.Id);
            return this.GridOperation(request, model);
        }
    }
}