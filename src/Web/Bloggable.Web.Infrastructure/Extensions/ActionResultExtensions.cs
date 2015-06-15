namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.ActionResults;

    public static class ActionResultExtensions
    {
        public static ActionResult WithSuccessAlert(this ActionResult actionResult, string message)
        {
            return new AlertDecoratorResult(actionResult, "alert-success", message);
        }

        public static ActionResult WithInfoAlert(this ActionResult actionResult, string message)
        {
            return new AlertDecoratorResult(actionResult, "alert-info", message);
        }

        public static ActionResult WithWarningAlert(this ActionResult actionResult, string message)
        {
            return new AlertDecoratorResult(actionResult, "alert-warning", message);
        }

        public static ActionResult WithErrorAlert(this ActionResult actionResult, string message)
        {
            return new AlertDecoratorResult(actionResult, "alert-danger", message);
        }
    }
}
