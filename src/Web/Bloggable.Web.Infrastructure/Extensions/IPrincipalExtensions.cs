namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Security.Principal;

    using Bloggable.Common.Constants;

    public static class IPrincipalExtensions
    {
        public static bool IsLoggedIn(this IPrincipal principal) => 
            principal != null && principal.Identity.IsAuthenticated;

        public static bool IsAdmin(this IPrincipal principal) => 
            principal != null && principal.IsInRole(RoleConstants.Administrator);
    }
}
