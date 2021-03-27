using GitEventTrackingApi.Service.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Service.Services
{
    public interface IActorService
    {
        List<ActorBusinessModel> GetActorsWithMaximumStreak();
    }
}
