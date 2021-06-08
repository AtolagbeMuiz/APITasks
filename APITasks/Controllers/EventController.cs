using APITasks.Models;
using APITasks.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APITasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        IEvent _repositoryEvent;

        public EventController(IEvent repositoryEvent, ILogger<EventController> logger)
        {
            _repositoryEvent = repositoryEvent;
            _logger = logger;
        }

        // POST: api/Event
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEvent([FromForm] UserEvents userEvents, [FromHeader] string authorization)
        {
            try
            {
                string apiKey;

                if (authorization == null)
                {
                    _logger.LogDebug("User with apiKey:{$apiKey} received this event response:{message}", authorization, "Access denied...");
                    return Unauthorized("Access denied...");
                }
                else
                {
                    apiKey = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                    _logger.LogInformation("User with apiKey:{$apiKey} sent this event request:{@userEvents}", apiKey, userEvents);
                }

                if (await _repositoryEvent.CreateEvent(userEvents) == "EventId already exists")
                {
                    _logger.LogDebug("User with apiKey:{$apiKey} received this event response:{message}", apiKey, "Event belongs to another user...");
                    return BadRequest("Event belongs to another user...");
                }
                else
                {
                    _logger.LogInformation("User with apiKey:{$apiKey} received this event response:{message}", apiKey, "Event have been created...");
                    return Ok("Event have been created...");
                }

            }
            catch (Exception exception)
            {
                _logger.LogError("Exception message:{exception}", exception);
                throw;
            }
        }
    }
}
