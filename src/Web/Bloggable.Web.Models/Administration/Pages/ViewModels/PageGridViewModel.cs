namespace Bloggable.Web.Models.Administration.Pages.ViewModels
{
    using System.ComponentModel.DataAnnotations;

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
        public string Permalink { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<PageGridViewModel, Page>().ForMember(e => e.CreatedOn, opt => opt.Ignore());
        }
    }
}
