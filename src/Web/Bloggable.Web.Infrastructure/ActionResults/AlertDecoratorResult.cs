namespace Bloggable.Web.Infrastructure.ActionResults
{
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.Extensions;
    using Bloggable.Web.Infrastructure.Models;

    public class AlertDecoratorResult : ActionResult
    {
        public AlertDecoratorResult(ActionResult inneResult, string alertClass, string message)
        {
            this.InnerResult = inneResult;
            this.AlertClass = alertClass;
            this.Message = message;
        }

        public ActionResult InnerResult { get; set; }

        public string AlertClass { get; set; }

        public string Message { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlerts();
            alerts.Add(new Alert(this.AlertClass, this.Message));
            this.InnerResult.ExecuteResult(context);
        }
    }
}
