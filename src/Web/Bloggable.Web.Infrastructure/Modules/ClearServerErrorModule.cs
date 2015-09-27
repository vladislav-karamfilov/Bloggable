namespace Bloggable.Web.Infrastructure.Modules
{
    using System;
    using System.Net;
    using System.Web;

    /// <remarks>
    /// This module allows using "customErrors" and "httpErrors" together in the Web.config. 
    /// Problem explanation: http://stackoverflow.com/questions/24465261/customerrors-vs-httperrors-a-significant-design-flaw
    /// Workaround: http://stackoverflow.com/questions/18276397/how-can-i-use-existingresponse-auto-successfully#answer-21271085
    /// IMPORTANT: Register the module after all error logging modules (like ELMAH) or implement logging logic in this module.
    /// </remarks>
    public class ClearServerErrorModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.Error += this.OnError;
        }

        public void Dispose()
        {
        }

        protected void OnError(object sender, EventArgs eventArgs)
        {
            var app = (HttpApplication)sender;
            var server = app.Server;

            var lastError = server.GetLastError();
            server.ClearError();

            // You can log the error here
            var httpException = lastError as HttpException;
            app.Response.StatusCode = httpException?.GetHttpCode() ?? (int)HttpStatusCode.InternalServerError;
        }
    }
}
