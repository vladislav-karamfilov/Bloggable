namespace Bloggable.Services.Administration.Contracts
{
    using Bloggable.Data.Models;

    public interface IPagesAdministrationService : IDeletableEntityAdministrationService<Page>
    {
        bool IsAvailablePagePermalink(string permalink, string initialPermalink = null);
    }
}
