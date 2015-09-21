namespace Bloggable.Services.Data
{
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

        public Page GetById(object id)
        {
            var page = this.pages.GetById(id);

            return page;
        }
    }
}