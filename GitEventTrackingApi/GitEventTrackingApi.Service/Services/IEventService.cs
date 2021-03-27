using GitEventTrackingApi.Service.BusinessModel;

namespace GitEventTrackingApi.Service.Services
{
    public interface IEventService
    {
        EventBusinessModel AddGitEvent(EventBusinessModel EventBusinessModel);
    }
}
