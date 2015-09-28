namespace Bloggable.Web.Infrastructure.ActionResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using Bloggable.Common.Constants;
    using Bloggable.Web.Infrastructure.ActionResults.Models;
    using Bloggable.Web.Infrastructure.Extensions;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    internal class StandardJsonResult : JsonResult
    {
        private readonly ICollection<string> errorMessages = new List<string>();

        public void AddError(string errorMessage)
        {
            this.errorMessages.Add(errorMessage);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("GET access is not allowed. Change the JsonRequestBehavior if you need GET access.");
            }

            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? ContentTypeConstants.Json : this.ContentType;

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            this.SerializeData(response);
        }

        protected virtual void SerializeData(HttpResponseBase response)
        {
            if (this.errorMessages.Any())
            {
                var originalData = this.Data;
                this.Data = new JsonResponse
                {
                    OriginalData = originalData,
                    ErrorMessages = this.errorMessages
                };

                // Set error response status code if it's not already set
                if (!response.IsError())
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                response.TrySkipIisCustomErrors = true;
            }

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[] { new StringEnumConverter(), },
                NullValueHandling = NullValueHandling.Ignore,
            };

            var serializedData = JsonConvert.SerializeObject(this.Data, settings);
            response.Write(serializedData);
        }
    }
}
