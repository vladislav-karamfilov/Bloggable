namespace Bloggable.Web.Models.Administration.Posts.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using Bloggable.Common.Constants;
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class PostGridViewModel : ContentHolderGridViewModel, IMapFrom<Post>, IMapTo<Post>, IHaveCustomMappings
    {
        [StringLength(
            ContentHolderValidationConstants.SummaryMaxLength,
            ErrorMessage = "{0} must be at most {1} characters long.")]
        [AllowHtml]
        [AdditionalMetadata("Height", "400px")]
        [UIHint("KendoEditor")]
        public string Summary { get; set; }

        // TODO: Separate to two properties
        public string ImageOrVideoUrl { get; set; }

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
