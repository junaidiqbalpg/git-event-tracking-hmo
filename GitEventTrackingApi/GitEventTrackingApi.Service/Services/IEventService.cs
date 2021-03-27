using GitEventTrackingApi.Service.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Service.Services
{
    public interface IEventService
    {
        EventBusinessModel AddGitEvent(EventBusinessModel EventBusinessModel);
    }
}
