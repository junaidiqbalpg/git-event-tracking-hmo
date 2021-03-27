using GitEventTrackingApi.Data.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

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
                 _context.SaveChanges();
                return _event;
            }
            catch (InvalidOperationException e)
            {
                _logger.LogError("Database error: " + e.Message);
                throw e;
            }
        }
    }
}
