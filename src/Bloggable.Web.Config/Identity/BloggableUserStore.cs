namespace Bloggable.Web.Config.Identity
{
    using System.Data.Entity;

    using Bloggable.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BloggableUserStore : UserStore<User>
    {
        public BloggableUserStore(DbContext context)
            : base(context)
        {
        }
    }
}