namespace Bloggable.Web.Config.Identity
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Bloggable.Data.Models;

    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user) =>
            user.GenerateUserIdentityAsync((ApplicationUserManager)this.UserManager);
    }
}