namespace Bloggable.Web.Models.Administration.Posts.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Bloggable.Common.Constants;
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;
    using Bloggable.Web.Infrastructure.Models;

    using Newtonsoft.Json;

    public class PostGridViewModel : 
        ContentHolderGridViewModel,
        IMapFrom<Post>,
        IMapTo<Post>,
        IHaveCustomMappings,
        ITaggableModel
    {
        private string mergedTags;

        public PostGridViewModel()
        {
            this.Tags = new List<Tag>();
        }

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

        [HiddenInput(DisplayValue = false)]
        public string AuthorUserName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AuthorId { get; set; }

        [Display(Name = "Tags")]
        [RegularExpression(
            TagValidationConstants.MergedTagsRegEx,
            ErrorMessage = "{0} should be strings with length between 2 and 30 characters separated by comma.")]
        public string MergedTags
        {
            get
            {
                if (this.Tags != null && this.Tags.Any())
                {
                    this.mergedTags = string.Join(", ", this.Tags.Select(t => t.Name));
                }

                return this.mergedTags;
            }

            set
            {
                this.mergedTags = value;
            }
        }

        [JsonIgnore]
        [ScaffoldColumn(false)]
        public ICollection<Tag> Tags { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<PostGridViewModel, Post>()
                .ForMember(e => e.CreatedOn, opt => opt.Ignore());
        }
    }
}
