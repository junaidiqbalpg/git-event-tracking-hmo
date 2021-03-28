using static GitEventTracking.Web.Helper.Common;

namespace GitEventTracking.Web.Services
{
    public interface IApiClient
    {
        string InvokeApi(ApiMethods method, string url, object content = null);
    }
}
