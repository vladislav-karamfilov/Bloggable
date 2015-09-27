namespace Bloggable.Web.Infrastructure.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Mvc;

    public class MvcResponseRewriteCustomErrorHandlerModule : IHttpModule
    {
        private CustomErrorsSection customErrors;

        public void Init(HttpApplication application)
        {
            var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            this.customErrors = (CustomErrorsSection)configuration.GetSection("system.web/customErrors");

            application.Error += this.OnError;
        }

        public void Dispose()
        {
        }

        protected void OnError(object sender, EventArgs e)
        {
            var httpContext = HttpContext.Current;
            if (this.customErrors.RedirectMode == CustomErrorsRedirectMode.ResponseRewrite && httpContext.IsCustomErrorEnabled)
            {
                var statusCode = this.GetStatusCode(httpContext);
                if ((HttpStatusCode)statusCode != HttpStatusCode.OK)
                {
                    var errorPaths = this.GetErrorPaths();

                    string url = null;

                    // Find a custom error path for this status code
                    if (errorPaths.ContainsKey(statusCode))
                    {
                        url = errorPaths[statusCode];
                    }
                    else if (!string.IsNullOrWhiteSpace(this.customErrors.DefaultRedirect))
                    {
                        url = this.customErrors.DefaultRedirect;
                    }

                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        var isCircularRedirect = httpContext.Request.Url.AbsolutePath.Equals(
                            VirtualPathUtility.ToAbsolute(url),
                            StringComparison.OrdinalIgnoreCase);
                        if (!isCircularRedirect)
                        {
                            httpContext.Response.Clear();
                            httpContext.Response.TrySkipIisCustomErrors = true;

                            httpContext.Server.ClearError();

                            // Do the redirect here
                            if (HttpRuntime.UsingIntegratedPipeline)
                            {
                                // Need to set the Response.StatusCode to the corresponding status code in the action
                                httpContext.Server.TransferRequest(url, true);
                            }
                            else
                            {
                                httpContext.RewritePath(url, false);

                                IHttpHandler httpHandler = new MvcHttpHandler();
                                httpHandler.ProcessRequest(httpContext);

                                // Return the original status code to the client (this won't work in integrated pipleline mode)
                                httpContext.Response.StatusCode = statusCode;
                            }
                        }
                    }
                }
            }
        }

        private IDictionary<int, string> GetErrorPaths() =>
            this.customErrors.Errors.Cast<CustomError>().ToDictionary(error => error.StatusCode, error => error.Redirect);

        private int GetStatusCode(HttpContext httpContext)
        {
            var statusCode = httpContext.Response.StatusCode;

            // If the request has thrown an exception then get the real status code
            var exception = httpContext.Error;
            if (exception != null)
            {
                // Set default error status code for application exceptions
                statusCode = (int)HttpStatusCode.InternalServerError;
            }

            var httpException = exception as HttpException;
            if (httpException != null)
            {
                statusCode = httpException.GetHttpCode();
            }

            return statusCode;
        }
    }
}
