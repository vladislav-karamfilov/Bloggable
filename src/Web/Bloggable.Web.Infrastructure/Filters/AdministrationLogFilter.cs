namespace Bloggable.Web.Infrastructure.Filters
{
    using System.Web.Mvc;

    using Bloggable.Data.Contracts;
    using Bloggable.Data.Models;
    using Bloggable.Web.Infrastructure.Attributes;
    using Bloggable.Web.Infrastructure.Filters.Contracts;

    using Microsoft.AspNet.Identity;

    public class AdministrationLogFilter : IActionFilter<AdministrationLogAttribute>
    {
        private readonly IRepository<AdministrationLog> administrationLogs;

        public AdministrationLogFilter(IRepository<AdministrationLog> administrationLogs)
        {
            this.administrationLogs = administrationLogs;
        }

        public void OnActionExecuting(AdministrationLogAttribute attribute, ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(AdministrationLogAttribute attribute, ActionExecutedContext filterContext)
        {
            var administrationLog = new AdministrationLog
            {
                IpAddress = filterContext.HttpContext.Request.UserHostAddress,
                Url = filterContext.HttpContext.Request.RawUrl,
                UserId = filterContext.HttpContext.User.Identity.GetUserId(),
                RequestType = filterContext.HttpContext.Request.RequestType,
                PostParams = filterContext.HttpContext.Request.Form.ToString(),
            };

            this.administrationLogs.Add(administrationLog);
            this.administrationLogs.SaveChanges();
        }
    }
}
