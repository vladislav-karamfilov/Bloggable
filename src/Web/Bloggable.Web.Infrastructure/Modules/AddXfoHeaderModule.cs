namespace Bloggable.Web.Infrastructure.Modules
{
    using System;
    using System.Web;

    public class AddXfoHeaderModule : IHttpModule
    {
        private const string XfoHeaderName = "X-Frame-Options";
        private const string XfoHeaderValue = "SAMEORIGIN";

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += this.ContextOnPreSendRequestHeaders;
        }

        public void Dispose()
        {
        }

        private void ContextOnPreSendRequestHeaders(object sender, EventArgs eventArgs)
        {
            var app = (HttpApplication)sender;
            app.Context.Response.Headers[XfoHeaderName] = XfoHeaderValue;
        }
    }
}
