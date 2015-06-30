namespace Bloggable.Services.Data
{
    using System.Data.Entity;
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

        public Page GetById(int id)
        {
            var page = this.pages
                .All()
                .Include(p => p.Tags)
                .FirstOrDefault(p => p.Id == id);

            return page;
        }
    }
}