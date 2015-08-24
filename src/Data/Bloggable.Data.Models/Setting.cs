﻿namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts;

    public class Setting : IdentifiableAuditInfo<string>
    {
        [Required]
        [MaxLength(AppSettingConstants.SettingValueMaxLength)]
        public string Value { get; set; }
    }
}
