using AutoMapper;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Data.Repository;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.Service.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Service.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRespository _eventRespository;
        private readonly IMapper _mapper;
        private readonly ILogger<IEventService> _logger;
        public EventService(IEventRespository eventRespoitory, IMapper mapper, 
            ILogger<EventService> logger)
        {
            _eventRespository = eventRespoitory;
            _mapper = mapper;
            _logger = logger;
        }

        public EventBusinessModel AddGitEvent(EventBusinessModel eventBusinessModel)
        {
            try
            {
                var _event = _mapper.Map<Event>(eventBusinessModel);
                return _mapper.Map<EventBusinessModel>(_eventRespository.AddEvent(_event));
            }
            catch (Exception e)
            {
                ExceptionHelper.ThrowAndLogValidationException(_logger, "Event with same name cannot be added.");
                return null;
            }
        }
    }
}
