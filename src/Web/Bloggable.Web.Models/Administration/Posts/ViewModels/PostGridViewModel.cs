namespace Bloggable.Web.Models.Administration.Posts.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class PostGridViewModel : AdministrationGridViewModel, IMapFrom<Post>, IMapTo<Post>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string SubTitle { get; set; }

        [AllowHtml]
        [AdditionalMetadata("Height", "400px")]
        [UIHint("KendoEditor")]
        public string Summary { get; set; }

        public string ImageOrVideoUrl { get; set; }

        [Required]
        [AllowHtml]
        [AdditionalMetadata("Height", "400px")]
        [UIHint("KendoEditor")]
        public string Content { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AuthorUserName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AuthorId { get; set; }

        public string Tags { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<PostGridViewModel, Post>().ForMember(m => m.CreatedOn, opt => opt.Ignore());
        }
    }
}
