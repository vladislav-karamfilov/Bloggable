namespace Bloggable.Web.Models.Administration.Settings.ViewModels
{
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class SettingGridViewModel : AdministrationGridViewModel, IMapFrom<Setting>, IMapTo<Setting>
    {
        public string Id { get; set; }

        public string Value { get; set; }
    }
}
