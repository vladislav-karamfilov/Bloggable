namespace Bloggable.Data
{
    using System.Data.Entity;

    using Bloggable.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BloggableDbContext : IdentityDbContext<User>, IBloggableDbContext
    {
        public BloggableDbContext()
            : base("DefaultConnection", false)
        {

        }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Page> Pages { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<SearchTerm> SearchTerms { get; set; }

        public virtual IDbSet<Feedback> Feedback { get; set; }

        public virtual IDbSet<Referral> Referrals { get; set; }
    }
}
