namespace Bloggable.Web.Config
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Bloggable.Common.Extensions;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IEnumerable<object> baseFilters)
        {
            baseFilters.ForEach(filters.Add);
            filters.Add(new HandleErrorAttribute());
        }
    }
}
