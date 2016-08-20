namespace Bloggable.Web.Models.Administration.Pages.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using Bloggable.Common.Constants;
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class PageGridViewModel : ContentHolderGridViewModel, IMapFrom<Page>, IMapTo<Page>, IHaveCustomMappings
    {
        [Display(Name = "Link")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(
            ContentHolderValidationConstants.UrlMaxLength,
            MinimumLength = ContentHolderValidationConstants.UrlMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        [RegularExpression(
            ContentHolderValidationConstants.PermalinkRegEx,
            ErrorMessage = "{0} should contain only latin and cyrillic letters, digits, underscore and dash.")]
        [Remote(
            "IsAvailablePermalink",
            "Pages",
            AdditionalFields = nameof(InitialPermalink),
            ErrorMessage = "The link is already used.")]
        public string Permalink { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string InitialPermalink { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Page, PageGridViewModel>()
                .ForMember(m => m.Permalink, opt => opt.MapFrom(e => e.Permalink));

            configuration.CreateMap<PageGridViewModel, Page>()
                .ForMember(e => e.CreatedOn, opt => opt.Ignore());
        }
    }
}
