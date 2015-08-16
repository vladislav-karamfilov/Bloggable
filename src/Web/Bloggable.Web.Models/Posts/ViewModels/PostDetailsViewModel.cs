namespace Bloggable.Web.Models.Posts.ViewModels
{
    using AutoMapper;

    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;
    using Bloggable.Web.Models.Home;

    public class PostDetailsViewModel : PostAnnotationViewModel, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostDetailsViewModel>()
                .IncludeBase<Post, PostAnnotationViewModel>();
        }
    }
}
