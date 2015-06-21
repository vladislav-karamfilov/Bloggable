namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;

    public class Page : ContentHolder
    {
        [MaxLength(ContentHolderValidationConstants.UrlMaxLength)]
        public string Permalink { get; set; }
    }
}
