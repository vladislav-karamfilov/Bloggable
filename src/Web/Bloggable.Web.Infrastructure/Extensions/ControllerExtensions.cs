namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Web.Mvc;

    public static class ControllerExtensions
    {
        public static ActionResult EmptyResult(this Controller controller)
        {
            return new EmptyResult();
        }
    }
}
