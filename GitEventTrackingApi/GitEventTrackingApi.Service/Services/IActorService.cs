using GitEventTrackingApi.Service.BusinessModel;
using System.Collections.Generic;

namespace GitEventTrackingApi.Service.Services
{
    public interface IActorService
    {
        List<ActorBusinessModel> GetActorsWithMaximumStreak();
    }
}
