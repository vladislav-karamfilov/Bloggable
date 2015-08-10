namespace Bloggable.Web.Models.Home
{
    using System;
    using System.Collections.Generic;

    using Bloggable.Common.Extensions;
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;
    using Bloggable.Web.Models.Common.ViewModels;

    public class PostAnnotationViewModel : IMapFrom<Post>
    {
        private IEnumerable<TagViewModel> tags;

        public int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Summary { get; set; }

        public string ImageOrVideoUrl { get; set; }

        public string AuthorUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UrlTitle
        {
            get { return this.Title.ToUrl(); }
        }

        public IEnumerable<TagViewModel> Tags
        {
            get { return this.tags ?? new TagViewModel[0]; }
            set { this.tags = value; }
        }
    }
}
