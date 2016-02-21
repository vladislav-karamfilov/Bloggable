namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Models.Base;

    public class SearchTerm : IdentifiableAuditInfo<int>
    {
        [Required]
        [MinLength(SearchTermValidationConstants.ContentMinLength)]
        [MaxLength(SearchTermValidationConstants.ContentMaxLength)]
        public string Content { get; set; }

        public int SearchCount { get; set; }
    }
}
