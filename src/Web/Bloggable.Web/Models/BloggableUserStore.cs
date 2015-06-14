namespace Bloggable.Web.Models
{
    using Bloggable.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BloggableUserStore : UserStore<User>
    {
        private readonly IdentityDbContext<User> context;

        public BloggableUserStore(IdentityDbContext<User> context)
        {
            this.context = context;
        }
    }
}