using GitEventTrackingApi.Service.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Service.Services
{
    public class ActorService : IActorService
    {
        public List<ActorBusinessModel> GetActorsWithMaximumStreak()
        {
            return new List<ActorBusinessModel>();
        }
    }
}
