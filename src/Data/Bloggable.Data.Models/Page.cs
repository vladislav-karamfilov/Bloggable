namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Bloggable.Common.Constants;

    public class Page : ContentHolder
    {
        // TODO: Add regular expression validation allowing only characters (latin and cyrillic), digits, -, _
        [Required]
        [Index(IsUnique = true)]
        [MinLength(ContentHolderValidationConstants.UrlMinLength)]
        [MaxLength(ContentHolderValidationConstants.UrlMaxLength)]
        public string Permalink { get; set; }
    }
}
