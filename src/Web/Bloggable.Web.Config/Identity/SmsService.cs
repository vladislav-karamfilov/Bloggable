namespace Bloggable.Web.Config.Identity
{
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message) => Task.FromResult(0);
    }
}