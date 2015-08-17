namespace Bloggable.Web.Infrastructure.ActionResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using Bloggable.Common.Constants;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    internal class StandardJsonResult : JsonResult
    {
        public ICollection<string> ErrorMessages { get; } = new List<string>();

        public void AddError(string errorMessage)
        {
            this.ErrorMessages.Add(errorMessage);
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
            if (this.ErrorMessages.Any())
            {
                var originalData = this.Data;
                this.Data = new
                {
                    Success = false,
                    OriginalData = originalData,
                    this.ErrorMessages
                };

                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[] { new StringEnumConverter(), },
            };

            response.Write(JsonConvert.SerializeObject(this.Data, settings));
        }
    }
}
