namespace Bloggable.Web.Infrastructure.ActionResults.Models
{
    using System.Collections.Generic;

    using Bloggable.Common.Extensions;

    internal class JsonResponse
    {
        public bool Success => this.ErrorMessages.IsNullOrEmpty();

        public object OriginalData { get; set; }

        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
