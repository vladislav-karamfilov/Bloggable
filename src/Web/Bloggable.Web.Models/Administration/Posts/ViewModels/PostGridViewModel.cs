namespace Bloggable.Web.Models.Administration.Posts.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using Bloggable.Common.Constants;
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class PostGridViewModel : TaggableAdministrationGridViewModel, IMapFrom<Post>, IMapTo<Post>, IHaveCustomMappings
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

        [StringLength(
            ContentHolderValidationConstants.SummaryMaxLength,
            ErrorMessage = "{0} must be at most {1} characters long.")]
        [AllowHtml]
        [AdditionalMetadata("Height", "400px")]
        [UIHint("KendoEditor")]
        public string Summary { get; set; }

        // TODO: Separate to two properties
        public string ImageOrVideoUrl { get; set; }

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

        [HiddenInput(DisplayValue = false)]
        public string AuthorUserName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AuthorId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<PostGridViewModel, Post>().ForMember(e => e.CreatedOn, opt => opt.Ignore());
        }
    }
}
