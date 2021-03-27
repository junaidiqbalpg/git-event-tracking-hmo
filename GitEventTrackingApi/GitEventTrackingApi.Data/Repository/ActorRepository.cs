using GitEventTrackingApi.Data.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitEventTrackingApi.Data.Repository
{
    public class ActorRepository : IActorRepository
    {
        private GitEventTrackingContext _context;
        private readonly ILogger<ActorRepository> _logger;

        public ActorRepository(GitEventTrackingContext context, ILogger<ActorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Actor> GetAllActors()
        {
            try
            {
                var actors = _context.Actor.ToList();

                return actors;
            }
            catch (Exception e)
            {
                _logger.LogError("Database error: " + e.Message);
                throw;
            }
        }
    }
}
