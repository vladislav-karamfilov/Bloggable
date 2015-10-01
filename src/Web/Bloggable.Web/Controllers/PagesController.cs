namespace Bloggable.Web.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper;

    using Bloggable.Services.Data.Contracts;
    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Models.Pages.ViewModels;

    public class PagesController : BaseController
    {
        private readonly IPagesDataService pagesData;

        public PagesController(IPagesDataService pagesData)
        {
            this.pagesData = pagesData;
        }

        public ActionResult Page(string id)
        {
            var page = this.pagesData.GetByPermalink(id);

            if (page == null)
            {
                return this.RedirectToAction<HomeController>(c => c.Index(null)).WithErrorAlert("No such page...");
            }

            var model = Mapper.Map<PageViewModel>(page);

            return this.View(model);
        }
    }
}