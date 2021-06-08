using APITasks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        IRegistration _repositoryRegistration;
        public RegistrationController(IRegistration repositoryRegistration)
        {
            _repositoryRegistration = repositoryRegistration;
        }

        // POST: api/Registration
        // [HttpPost("[action]")]
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromForm] RegisterUser registerUser)
        {
            if (await _repositoryRegistration.RegisterUser(registerUser) == true)
            {
                return BadRequest("User already exists...");
            }
            else
            {
                return Ok("Registration was successful...");
            }
        }
    }
}
