namespace Bloggable.Web.Config.Identity
{
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    public class EmailService : IIdentityMessageService
    {
        // Plug in your email service here to send an email.
        public Task SendAsync(IdentityMessage message) => Task.FromResult(0);
    }
}
