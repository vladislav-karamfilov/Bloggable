namespace Bloggable.Web.Models.Posts.ViewModels
{
    using System.Collections.Generic;

    using Bloggable.Common.Extensions;
    using Bloggable.Web.Models.Home;

    public class PostsByTagViewModel
    {
        private string tagUrlName;

        public PostsByTagViewModel()
        {
            this.Posts = new PostAnnotationViewModel[0];
        }

        public int TagId { get; set; }

        public string TagName { get; set; }

        public string TagUrlName
        {
            get { return string.IsNullOrWhiteSpace(this.tagUrlName) ? this.TagName.ToUrl() : this.tagUrlName; }
            set { this.tagUrlName = value; }
        }

        public IEnumerable<PostAnnotationViewModel> Posts { get; set; }
    }
}
