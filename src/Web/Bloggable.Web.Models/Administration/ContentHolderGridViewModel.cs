namespace Bloggable.Web.Models.Administration
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Bloggable.Common.Constants;

    public abstract class ContentHolderGridViewModel : TaggableAdministrationGridViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(
            ContentHolderValidationConstants.TitleMaxLength,
            MinimumLength = ContentHolderValidationConstants.ContentMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Title { get; set; }

        [Display(Name = "Subtitle")]
        [StringLength(
            ContentHolderValidationConstants.TitleMaxLength,
            MinimumLength = ContentHolderValidationConstants.ContentMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string SubTitle { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(
            ContentHolderValidationConstants.ContentMaxLength,
            MinimumLength = ContentHolderValidationConstants.ContentMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        [AllowHtml]
        [AdditionalMetadata("Height", "400px")]
        [UIHint("KendoEditor")]
        public string Content { get; set; }

        [Display(Name = "Meta description")]
        [StringLength(
            ContentHolderValidationConstants.MetaDescriptionMaxLength,
            MinimumLength = ContentHolderValidationConstants.MetaDescriptionMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string MetaDescription { get; set; }

        [Display(Name = "Meta keywords")]
        [StringLength(
            ContentHolderValidationConstants.MetaKeywordsMaxLength,
            MinimumLength = ContentHolderValidationConstants.MetaKeywordsMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string MetaKeywords { get; set; }
    }
}
