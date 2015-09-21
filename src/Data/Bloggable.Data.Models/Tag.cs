namespace Bloggable.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts;

    public class Tag : IdentifiableAuditInfo<int>
    {
        private ICollection<Post> posts;

        public Tag()
        {
            this.posts = new HashSet<Post>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(TagValidationConstants.TagNameMinLength)]
        [MaxLength(TagValidationConstants.TagNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
