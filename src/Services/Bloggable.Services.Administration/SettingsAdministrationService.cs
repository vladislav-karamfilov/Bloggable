namespace Bloggable.Services.Administration
{
    using System.Linq;

    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Models;
    using Bloggable.Services.Administration.Base;
    using Bloggable.Services.Administration.Contracts;

    public class SettingsAdministrationService : AdministrationService<Setting>, ISettingsAdministrationService
    {
        public SettingsAdministrationService(IRepository<Setting> entities)
            : base(entities)
        {
        }

        public bool IsAvailableSettingKey(string key) => this.Entities.All().All(s => s.Id != key);
    }
}
