namespace Bloggable.Web.Models.Administration.Settings.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class SettingGridViewModel : AdministrationGridViewModel, IMapFrom<Setting>, IMapTo<Setting>
    {
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Key")]
        public string Id { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(AppSettingConstants.SettingValueMaxLength, ErrorMessage = "{0} should be at least {1} characters long.")]
        public string Value { get; set; }
    }
}
