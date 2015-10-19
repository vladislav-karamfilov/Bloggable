namespace Bloggable.Services.Administration
{
    using System;
    using System.Linq;

    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Models;
    using Bloggable.Services.Administration.Base;
    using Bloggable.Services.Administration.Contracts;

    public class PagesAdministrationService : DeletableEntityAdministrationService<Page>, IPagesAdministrationService
    {
        public PagesAdministrationService(IDeletableEntityRepository<Page> entities)
            : base(entities)
        {
        }

        public bool IsAvailablePagePermalink(string permalink, string initialPermalink = null)
        {
            var isInitialPermalinkEqualToCurrent = permalink?.Trim().Equals(initialPermalink?.Trim(), StringComparison.OrdinalIgnoreCase) ?? false;

            var result = isInitialPermalinkEqualToCurrent || this.Entities.AllWithDeleted().All(p => p.Permalink != permalink);
            return result;
        } 
    }
}
