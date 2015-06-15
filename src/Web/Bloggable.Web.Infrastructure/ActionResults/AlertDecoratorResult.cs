namespace Bloggable.Web.Infrastructure.ActionResults
{
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Infrastructure.Models;

    public class AlertDecoratorResult : ActionResult
    {
        public AlertDecoratorResult(ActionResult inneResult, AlertType alertType, string message)
        {
            this.InnerResult = inneResult;
            this.AlertType = alertType;
            this.Message = message;
        }

        public ActionResult InnerResult { get; set; }

        public AlertType AlertType { get; set; }

        public string Message { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlerts();
            alerts.Add(new Alert(this.AlertType, this.Message));
            this.InnerResult.ExecuteResult(context);
        }
    }
}
