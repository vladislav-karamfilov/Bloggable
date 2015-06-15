namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.Models;

    public static class TempDataDictionaryExtensions
    {
        private const string AlertsKey = "_Alerts";

        public static ICollection<Alert> GetAlerts(this TempDataDictionary tempData)
        {
            if (!tempData.ContainsKey(AlertsKey))
            {
                tempData[AlertsKey] = new List<Alert>();
            }

            return (ICollection<Alert>)tempData[AlertsKey];
        }
    }
}
