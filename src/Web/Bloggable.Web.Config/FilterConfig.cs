namespace Bloggable.Web.Config
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Bloggable.Common.Extensions;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IEnumerable<object> otherFilters = null)
        {
            filters.Add(new HandleErrorAttribute());

            otherFilters = otherFilters ?? Enumerable.Empty<object>();

            otherFilters.ForEach(filters.Add);
        }
    }
}
