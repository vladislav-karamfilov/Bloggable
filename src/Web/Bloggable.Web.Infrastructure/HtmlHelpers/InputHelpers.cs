namespace Bloggable.Web.Infrastructure.HtmlHelpers
{
    using System.Web.Mvc;

    using HtmlTags;

    public static class InputHelpers
    {
        public static HtmlTag Submit(this HtmlHelper helper, string value = "Submit")
        {
            var inputSubmit = new HtmlTag("input")
                .Attr("type", "submit")
                .Attr("value", value);

            return inputSubmit;
        }
    }
}
