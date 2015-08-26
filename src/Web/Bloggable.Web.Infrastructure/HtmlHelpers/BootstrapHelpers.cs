namespace Bloggable.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class BootstrapHelpers
    {
        public static IHtmlString BootstrapLabelFor<TModel, TProp>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProp>> expression) => 
            helper.LabelFor(expression, new { @class = "control-label" });
    }
}
