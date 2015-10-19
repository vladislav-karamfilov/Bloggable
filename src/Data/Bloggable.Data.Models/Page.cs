namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Bloggable.Common.Constants;

    public class Page : ContentHolder
    {
        [Required]
        [Index(IsUnique = true)]
        [MinLength(ContentHolderValidationConstants.UrlMinLength)]
        [MaxLength(ContentHolderValidationConstants.UrlMaxLength)]
        [RegularExpression(ContentHolderValidationConstants.PermalinkRegEx)]
        public string Permalink { get; set; }
    }
}
