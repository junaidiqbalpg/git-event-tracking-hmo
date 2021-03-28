using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GitEventTracking.Web.Helper
{
    public class Common
    {
        public enum ApiMethods
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public static string GetAppSettingValue(string key)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var appSetting = root.GetSection(key).Value;

            return appSetting;
        }
    }
}
