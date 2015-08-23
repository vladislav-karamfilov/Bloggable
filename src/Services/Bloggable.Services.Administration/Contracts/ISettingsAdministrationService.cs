namespace Bloggable.Services.Administration.Contracts
{
    using Bloggable.Data.Models;

    public interface ISettingsAdministrationService : IAdministrationService<Setting>
    {
        bool IsAvailableSettingKey(string key);
    }
}
