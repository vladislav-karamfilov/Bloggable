namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.ActionResults;
    using Bloggable.Web.Infrastructure.Models;

    public static class ActionResultExtensions
    {
        public static ActionResult WithSuccessAlert(this ActionResult actionResult, string message) => 
            new AlertDecoratorResult(actionResult, AlertType.Success, message);

        public static ActionResult WithInfoAlert(this ActionResult actionResult, string message) => 
            new AlertDecoratorResult(actionResult, AlertType.Info, message);

        public static ActionResult WithWarningAlert(this ActionResult actionResult, string message) => 
            new AlertDecoratorResult(actionResult, AlertType.Warning, message);

        public static ActionResult WithErrorAlert(this ActionResult actionResult, string message) => 
            new AlertDecoratorResult(actionResult, AlertType.Error, message);
    }
}
