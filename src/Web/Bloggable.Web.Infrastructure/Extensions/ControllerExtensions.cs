namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Linq;
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.ActionResults;

    public static class ControllerExtensions
    {
        public static ActionResult EmptyResult(this Controller controller)
            => new EmptyResult();

        public static ActionResult JsonSuccess<T>(this Controller controller, T data)
            => new StandardJsonResult { Data = data };

        public static JsonResult JsonError(this Controller controller, string errorMessage)
        {
            var result = new StandardJsonResult();

            result.AddError(errorMessage);

            return result;
        }

        public static JsonResult JsonValidation(this Controller controller)
        {
            var result = new StandardJsonResult();

            var validationMessages = controller.ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            foreach (var validationMessage in validationMessages)
            {
                result.AddError(validationMessage);
            }

            return result;
        }
    }
}
