namespace Bloggable.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Data.Contracts;

    public abstract class ContentHolder : IdentifiableDeletableEntity<int>
    {
        private ICollection<Tag> tags;

        protected ContentHolder()
        {
            this.tags = new HashSet<Tag>();
        }

        [Required]
        public string Title { get; set; }

        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
