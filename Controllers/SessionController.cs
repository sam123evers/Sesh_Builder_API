using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_RPG.Models;
using dotnet_RPG.Services.SessionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public IActionResult Get()
        {
            return Ok(_sessionService.GetAllSessions());
        }

        [HttpGet("{id}")]
        public IActionResult GetSessionById(int id)
        {
            var session = _sessionService.GetSessionById(id);
            return Ok(session);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession(Session newSession)
        {
            await _sessionService.AddSession(newSession);
            return Ok(_sessionService.GetAllSessions());
        }

        //[HttpPut]
        // public IActionResult UpdateSession(Session session)
        // {
        //     // Update Existing Session
        //     //  -provide Session id and pose list
        //     //  -reinsert pose list for session
        // }
    }
}