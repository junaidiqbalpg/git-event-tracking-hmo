using Newtonsoft.Json;
using System;
using System.Net;
using static GitEventTracking.Web.Helper.Common;

namespace GitEventTracking.Web.Services
{
    public class ApiClient : IApiClient
    {
        public ApiClient()
        { }

        public string InvokeApi(ApiMethods method, string url, object content = null)
        {
            string response = string.Empty;
            switch (method)
            {
                case ApiMethods.GET:
                    response = this.InvokeGet(url);
                    break;
                case ApiMethods.POST:
                case ApiMethods.PUT:
                case ApiMethods.DELETE:
                    response = this.InvokePost(method, url, content);
                    break;
                default:
                    response = this.InvokePost(method, url, content);
                    break;
            }

            return response;
        }

        private string InvokePost(ApiMethods method, string url, object content)
        {
            string jsonResponse = string.Empty;
            string apiToken = GetAppSettingValue("AppSettings:ApiKey");

            using (var client = new WebClient())
            {
                try
                {
                    client.UseDefaultCredentials = true;
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("ApiKey", apiToken);

                    var uri = new Uri(url);
                    var requestContent = JsonConvert.SerializeObject(content);
                    var response = client.UploadString(uri, method.ToString(), requestContent);
                    jsonResponse = response;
                }
                catch (WebException ex)
                {
                    var webResponse = (HttpWebResponse)ex.Response;
                    var statusCode = (int)webResponse.StatusCode;
                    var msg = webResponse.StatusDescription;
                    var error = string.Format("StatusCode: {0}, Message: {1}, Exception: {2}", statusCode, msg, ex.Message);
                    throw new WebException(error);
                }
            }

            return jsonResponse;
        }

        private string InvokeGet(string url)
        {
            string jsonResponse = string.Empty;
            string apiToken = GetAppSettingValue("AppSettings:ApiKey");

            using (var client = new WebClient())
            {
                try
                {
                    client.UseDefaultCredentials = true;
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("ApiKey", apiToken);

                    var uri = new Uri(url);

                    var response = client.DownloadString(uri);
                    jsonResponse = response;
                }
                catch (WebException ex)
                {
                    var webResponse = (HttpWebResponse)ex.Response;
                    var statusCode = (int)webResponse.StatusCode;
                    var msg = webResponse.StatusDescription;
                    var error = string.Format("StatusCode: {0}, Message: {1}, Exception: {2}", statusCode, msg, ex.Message);
                    throw new WebException(error);
                }
            }

            return jsonResponse;
        }
    }
}
