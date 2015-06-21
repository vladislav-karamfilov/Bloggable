namespace Bloggable.Web.Infrastructure.Extensions
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Bloggable.Common.Constants;

    public static class ViewDataDictionaryExtensions
    {
        public static string GetSystemSetting(this ViewDataDictionary viewData, string key)
        {
            string result = null;

            if (viewData.ContainsKey(AppSettingConstants.SystemSettingsViewDataKey))
            {
                var systemSettings = viewData[AppSettingConstants.SystemSettingsViewDataKey] as IDictionary<string, string>;
                if (systemSettings != null && systemSettings.ContainsKey(key))
                {
                    result = systemSettings[key];
                }
            }

            return result;
        }
    }
}
