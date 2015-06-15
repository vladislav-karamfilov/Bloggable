namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.Models;

    public static class TempDataDictionaryExtensions
    {
        private const string AlertsKey = "_Alerts";

        public static ICollection<Alert> GetAlerts(this TempDataDictionary tempData, AlertType? type = null)
        {
            if (!tempData.ContainsKey(AlertsKey))
            {
                tempData[AlertsKey] = new List<Alert>();
            }

            var alerts = (ICollection<Alert>)tempData[AlertsKey];

            if (type.HasValue)
            {
                alerts = alerts.Where(a => a.Type == type.Value).ToList();
            }

            return alerts;
        }
    }
}
