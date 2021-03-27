using GitEventTrackingApi.Data.Domain;
using System.Collections.Generic;

namespace GitEventTrackingApi.Data.Repository
{
    public interface IEventRespository
    {
        Event AddEvent(Event _event);
        List<Event> GetAllEvents();
    }
}
