namespace Bloggable.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Bloggable.Data.Models;
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Web.Areas.Administration.Controllers.Base;
    using Bloggable.Web.Models.Administration.Posts.ViewModels;

    using Kendo.Mvc.UI;

    public class PostsController : KendoGridAdministrationController
    {
        private readonly IDeletableEntityAdministrationService<Post> administrationService;

        public PostsController(IDeletableEntityAdministrationService<Post> administrationService)
        {
            this.administrationService = administrationService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, PostGridViewModel model)
        {
            this.administrationService.Delete(model.Id);
            return this.GridOperation(request, model);
        }

        protected override IEnumerable GetData()
        {
            return this.administrationService.Read().AsQueryable().Project().To<PostGridViewModel>();
        }
    }
}