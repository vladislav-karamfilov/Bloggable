namespace Bloggable.Web.Infrastructure.Modules
{
    using System;
    using System.Web;

    public class RemoveServerHeaderModule : IHttpModule
    {
        private const string ServerHeaderName = "Server";

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += this.OnPreSendRequestHeaders;
        }

        public void Dispose()
        {
        }

        private void OnPreSendRequestHeaders(object sender, EventArgs eventArgs)
        {
            var app = (HttpApplication)sender;
            app.Context.Response.Headers.Remove(ServerHeaderName);
        }
    }
}
