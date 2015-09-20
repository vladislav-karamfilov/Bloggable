namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Web;

    public static class HttpRequestExtensions
    {
        public static bool IsAjax(this HttpRequest request) => 
            request["X-Requested-With"] == "XMLHttpRequest" ||
            request.Headers["X-Requested-With"] == "XMLHttpRequest";
    }
}
