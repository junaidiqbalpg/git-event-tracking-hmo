using AutoMapper;
using GitEventTrackingApi.Data.Repository;
using GitEventTrackingApi.Service.BusinessModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Service.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRespository;
        private readonly IMapper _mapper;
        public ActorService(IActorRepository actorRespository, IMapper mapper)
        {
            _actorRespository = actorRespository;
            _mapper = mapper;
        }

        public List<ActorBusinessModel> GetActorsWithMaximumStreak()
        {
            var allActors = _actorRespository.GetAllActors();
            return new List<ActorBusinessModel>();
        }
    }
}
