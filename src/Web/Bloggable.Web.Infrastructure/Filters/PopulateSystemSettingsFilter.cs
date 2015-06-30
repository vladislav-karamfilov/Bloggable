namespace Bloggable.Web.Infrastructure.Filters
{
    using System.Web.Mvc;

    using Bloggable.Common.Constants;
    using Bloggable.Services.Common.Cache.Contracts;
    using Bloggable.Web.Infrastructure.Attributes;
    using Bloggable.Web.Infrastructure.Filters.Contracts;

    public class PopulateSystemSettingsFilter : IActionFilter<PopulateSystemSettingsAttribute>
    {
        private readonly ICacheItemsProviderService cacheItemsProvider;

        public PopulateSystemSettingsFilter(ICacheItemsProviderService cacheItemsProvider)
        {
            this.cacheItemsProvider = cacheItemsProvider;
        }

        public void OnActionExecuting(PopulateSystemSettingsAttribute attribute, ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(PopulateSystemSettingsAttribute attribute, ActionExecutedContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Result is ViewResultBase)
            {
                filterContext.Controller.ViewData[AppSettingConstants.SystemSettingsViewDataKey] =
                    this.cacheItemsProvider.GetSettings(3 * CacheConstants.DefaultCacheSeconds);
            }
        }
    }
}
