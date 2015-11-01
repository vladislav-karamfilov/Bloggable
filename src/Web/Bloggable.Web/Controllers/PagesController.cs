namespace Bloggable.Web.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using Bloggable.Services.Common.Mapping.Contracts;
    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Models.Pages.ViewModels;

    public class PagesController : BaseController
    {
        private readonly IPagesDataService pagesData;
        private readonly IMappingService mappingService;

        public PagesController(IPagesDataService pagesData, IMappingService mappingService)
        {
            this.pagesData = pagesData;
            this.mappingService = mappingService;
        }

        public ActionResult Page(string id)
        {
            var page = this.pagesData.GetByPermalink(id);

            if (page == null)
            {
                return this.RedirectToAction<HomeController>(c => c.Index(null)).WithErrorAlert("No such page...");
            }

            var model = this.mappingService.Map<PageViewModel>(page);

            return this.View(model);
        }
    }
}