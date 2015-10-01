namespace Bloggable.Services.Data
{
    using System.Linq;

    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Models;
    using Bloggable.Services.Data.Contracts;

    public class PagesDataService : IPagesDataService
    {
        private readonly IDeletableEntityRepository<Page> pages;

        public PagesDataService(IDeletableEntityRepository<Page> pages)
        {
            this.pages = pages;
        }

        public Page GetByPermalink(string permalink, bool includeDeleted = false)
        {
            var allPages = includeDeleted ? this.pages.AllWithDeleted() : this.pages.All();

            var page = allPages.FirstOrDefault(p => p.Permalink == permalink);

            return page;
        }
    }
}