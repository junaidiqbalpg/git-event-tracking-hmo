using GitEventTrackingApi.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitEventTrackingApi.Data.Repository
{
    public class EventRespository : IEventRespository
    {
        private GitEventTrackingContext _context;
        private readonly ILogger<EventRespository> _logger;

        public EventRespository(GitEventTrackingContext context, ILogger<EventRespository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Event AddEvent(Event _event)
        {
            try
            {
                 _context.Event.Add(_event);
                 
                 if (_context.Actor.Any(a => a.id == _event.actor.id))
                 {
                     _context.Entry(_event.actor).State = EntityState.Unchanged;
                 }

                 if (_context.Repo.Any(a => a.id == _event.repo.id))
                 {
                     _context.Entry(_event.repo).State = EntityState.Unchanged;
                 }

                _context.SaveChanges();
                return _event;
            }
            catch (InvalidOperationException e)
            {
                _logger.LogError("Database error: " + e.Message);
                throw e;
            }
        }

        public List<Event> GetAllEvents()
        {
            try
            {
                var actors = _context.Event
                    .Include(p => p.actor)
                    .Include(p => p.repo)
                    .ToList();

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
