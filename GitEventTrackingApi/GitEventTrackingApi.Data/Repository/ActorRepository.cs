using GitEventTrackingApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Data.Repository
{
    public class ActorRepository : IActorRepository
    {
        public List<Actor> GetAllActors()
        {
            return new List<Actor>();
        }
    }
}
