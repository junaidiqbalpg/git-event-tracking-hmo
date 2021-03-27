using AutoMapper;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Data.Repository;
using GitEventTrackingApi.Service.BusinessModel;
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
            var _event = _mapper.Map<Event>(eventBusinessModel);
            var test = _eventRespository.AddEvent(_event);
            return _mapper.Map<EventBusinessModel>(_eventRespository.AddEvent(_event));
        }
    }
}
