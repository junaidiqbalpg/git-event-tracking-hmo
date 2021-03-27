using AutoMapper;
using GitEventTrackingApi.Service.Services;
using GitEventTrackingApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GitEventTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private IActorService _actorService;
        private readonly IMapper _mapper;

        public ActorController(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }

        [HttpGet("streak")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult<List<ActorViewModel>> GetStreak()
        {
            try
            {
                var result = _actorService.GetActorsWithMaximumStreak();
                
                return Ok(_mapper.Map<List<ActorViewModel>>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}