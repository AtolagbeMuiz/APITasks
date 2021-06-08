using APITasks.Models;
using APITasks.Repository;
using APITasks.Services;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _repositoryAuthenticationService;
        private ILogin _repositoryLogin;

        public AuthenticationController(ILogin repositoryLogin, IAuthenticationService repositoryAuthenticationService)
        {
            _repositoryLogin = repositoryLogin;
            _repositoryAuthenticationService = repositoryAuthenticationService;
        }

        // POST: api/Authentication
        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn([FromForm] LoginUser loginUser)
        {
            if (await _repositoryLogin.LoginUser(loginUser) == true)
            {
                string token = await _repositoryAuthenticationService.Authenticate(loginUser);
                var formattedToken = FormatToken.FormattedToken(token);
                return Ok(formattedToken);
            }
            else
            {
                return NotFound("There's no such user...");

                //string token = await _repositoryAuthenticationService.Authenticate(loginUser);
                //return NotFound(token);
            }

        }
    }
}
