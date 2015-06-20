namespace Bloggable.Web.Models.Administration.Comments.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class CommentGridViewModel : AdministrationGridViewModel, IMapFrom<Comment>
    {
        public int Id { get; set; }

        [Display(Name = "Author")]
        public string AuthorUserName { get; set; }

        public string Content { get; set; }

        [Display(Name = "Deleted?")]
        public bool IsDeleted { get; set; }
    }
}
