namespace Bloggable.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Data.Contracts;

    public class Tag : IdentifiableAuditInfo<int>
    {
        private ICollection<Post> posts;
        private ICollection<Page> pages;

        public Tag()
        {
            this.posts = new HashSet<Post>();
            this.pages = new HashSet<Page>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<Page> Pages
        {
            get { return this.pages; }
            set { this.pages = value; }
        }
    }
}
