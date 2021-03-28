using Microsoft.Extensions.Configuration;
using System.IO;

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
