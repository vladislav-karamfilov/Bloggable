namespace Bloggable.Web.Infrastructure.Filters
{
    using System.Web.Mvc;

    using Bloggable.Common.Constants;
    using Bloggable.Services.Common.Cache.Contracts;
    using Bloggable.Web.Infrastructure.Attributes;
    using Bloggable.Web.Infrastructure.Filters.Contracts;

    public class PopulateSystemSettingsViewDataActionFilter : IActionFilter<PopulateSystemSettingsViewDataAttribute>
    {
        private readonly ICacheItemsProviderService cacheItemsProvider;

        public PopulateSystemSettingsViewDataActionFilter(ICacheItemsProviderService cacheItemsProvider)
        {
            this.cacheItemsProvider = cacheItemsProvider;
        }

        public void OnActionExecuting(PopulateSystemSettingsViewDataAttribute viewDataAttribute, ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData[AppSettingConstants.SystemSettingsViewDataKey] =
                this.cacheItemsProvider.GetSettings(3 * CacheConstants.DefaultCacheSeconds);
        }

        public void OnActionExecuted(PopulateSystemSettingsViewDataAttribute viewDataAttribute, ActionExecutedContext filterContext)
        {
        }
    }
}
