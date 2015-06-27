namespace Bloggable.Web.Models.Home
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;
    using Bloggable.Web.Models.Common;

    public class PostAnnotationViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        private IEnumerable<TagViewModel> tags;

        public int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Summary { get; set; }

        public string ImageOrVideoUrl { get; set; }

        public string AuthorUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        //public string Url
        //{
        //    get { return this.urlGenerator }
        //}

        public IEnumerable<TagViewModel> Tags
        {
            get { return this.tags ?? new TagViewModel[0]; }
            set { this.tags = value; }
        }

        public void CreateMappings(IConfiguration configuration)
        {
           // configuration.CreateMap<Post, PostAnnotationViewModel>()
             //   .ConstructUsingServiceLocator()
        }
    }
}
