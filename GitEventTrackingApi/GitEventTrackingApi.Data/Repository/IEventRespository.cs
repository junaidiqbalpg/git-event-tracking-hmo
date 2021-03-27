using GitEventTrackingApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Data.Repository
{
    public interface IEventRespository
    {
        Event AddEvent(Event _event);
    }
}
