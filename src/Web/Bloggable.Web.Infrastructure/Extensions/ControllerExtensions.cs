namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    using Bloggable.Common.Constants;
    using Bloggable.Web.Infrastructure.ActionResults;

    public static class ControllerExtensions
    {
        public static ActionResult EmptyResult(this Controller controller)
            => new EmptyResult();

        public static ActionResult JsonSuccess(
                this Controller controller,
                object data,
                string contentType = null,
                Encoding contentEncoding = null,
                JsonRequestBehavior jsonRequestBehavior = JsonRequestBehavior.DenyGet)
            => new StandardJsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = jsonRequestBehavior,
            };

        public static JsonResult JsonError(
            this Controller controller,
            string errorMessage,
            string contentType = null,
            Encoding contentEncoding = null,
            JsonRequestBehavior jsonRequestBehavior = JsonRequestBehavior.DenyGet)
        {
            var result = new StandardJsonResult
            {
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = jsonRequestBehavior,
            };

            result.AddError(errorMessage);

            return result;
        }

        public static JsonResult JsonValidation(
            this Controller controller,
            string contentType = null,
            Encoding contentEncoding = null,
            JsonRequestBehavior jsonRequestBehavior = JsonRequestBehavior.DenyGet)
        {
            var result = new StandardJsonResult
            {
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = jsonRequestBehavior,
            };

            var validationMessages = controller.ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            foreach (var validationMessage in validationMessages)
            {
                result.AddError(validationMessage);
            }

            return result;
        }
    }
}
