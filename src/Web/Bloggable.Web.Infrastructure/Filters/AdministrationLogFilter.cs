namespace Bloggable.Web.Infrastructure.Filters
{
    using System;
    using System.Web.Mvc;

    using Bloggable.Data.Models;
    using Bloggable.Services.Administration.Contracts;
    using Bloggable.Web.Infrastructure.Attributes;
    using Bloggable.Web.Infrastructure.Filters.Contracts;

    using Microsoft.AspNet.Identity;

    public class AdministrationLogFilter : IActionFilter<AdministrationLogAttribute>
    {
        private readonly IAdministrationService<AdministrationLog> administrationLogs;

        public AdministrationLogFilter(IAdministrationService<AdministrationLog> administrationLogs)
        {
            if (administrationLogs == null)
            {
                throw new ArgumentNullException(nameof(administrationLogs));
            }

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
                PostParams = filterContext.HttpContext.Request.Unvalidated.Form.ToString()
            };

            this.administrationLogs.Create(administrationLog);
        }
    }
}
