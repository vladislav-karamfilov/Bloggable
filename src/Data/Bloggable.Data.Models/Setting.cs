namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Models.Base;

    public class Setting : IdentifiableAuditInfo<string>
    {
        [Required]
        [MaxLength(AppSettingConstants.SettingValueMaxLength)]
        public string Value { get; set; }
    }
}
