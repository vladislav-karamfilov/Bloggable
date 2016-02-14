namespace Bloggable.Web.Models.Comments.ViewModels
{
    using System;

    using AutoMapper;

    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(e => e.Author.UserName));
        }
    }
}
