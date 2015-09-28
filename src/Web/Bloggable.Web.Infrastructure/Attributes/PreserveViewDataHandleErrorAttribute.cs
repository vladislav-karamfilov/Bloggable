namespace Bloggable.Web.Infrastructure.Attributes
{
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.ActionResults;

    public class PreserveViewDataHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            if (!filterContext.IsChildAction &&
                !filterContext.ExceptionHandled &&
                filterContext.HttpContext.IsCustomErrorEnabled &&
                new HttpException(null, filterContext.Exception).GetHttpCode() == (int)HttpStatusCode.InternalServerError &&
                this.ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var jsonResult = new StandardJsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    jsonResult.AddError(filterContext.Exception.Message);

                    filterContext.Result = jsonResult;
                }
                else
                {
                    var controllerName = (string)filterContext.RouteData.Values["controller"];
                    var actionName = (string)filterContext.RouteData.Values["action"];

                    var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                    var viewData = new ViewDataDictionary<HandleErrorInfo>(filterContext.Controller.ViewData)
                    {
                        Model = model
                    };

                    filterContext.Result = new ViewResult
                    {
                        ViewName = this.View,
                        MasterName = this.Master,
                        ViewData = viewData,
                        TempData = filterContext.Controller.TempData
                    };
                }

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}
