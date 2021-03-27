﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GitEventTrackingApi.Service.BindingModel;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.Service.Services;
using GitEventTrackingApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitEventTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public IActionResult AddNewEvent(EventBindingModel eventBindingModel)
        {
            try
            {
                var result =  _eventService.AddGitEvent(_mapper.Map<EventBusinessModel>(eventBindingModel));

                return CreatedAtAction(nameof(AddNewEvent), new { eventId = result.id }, _mapper.Map<EventViewModel>(result));
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}