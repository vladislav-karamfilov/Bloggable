namespace Bloggable.Web.Models.Administration.Posts.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class PostGridViewModel : AdministrationViewModel, IMapFrom<Post>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string SubTitle { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AuthorUserName { get; set; }
    }
}
