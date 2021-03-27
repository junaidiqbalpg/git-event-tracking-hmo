using GitEventTrackingApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Data.Repository
{
    public interface IActorRepository
    {
        List<Actor> GetAllActors();
    }
}
