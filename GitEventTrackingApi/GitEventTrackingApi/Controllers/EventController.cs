using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitEventTrackingApi.Service.BindingModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitEventTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public IActionResult AddNewEvent(EventBindingModel eventBindingModel)
        {
            return Ok();
        }
    }
}