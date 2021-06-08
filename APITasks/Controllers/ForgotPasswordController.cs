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
    public class ForgotPasswordController : ControllerBase
    {
        IRegistration _repositoryRegistration;

        public ForgotPasswordController(IRegistration repositoryRegistration)
        {
            _repositoryRegistration = repositoryRegistration;
        }

        // POST: api/ForgotPassword
        [HttpPost("[action]")]
        public async Task<IActionResult> PasswordResetEmail([FromForm] string email)
        {

            string resetCode = Guid.NewGuid().ToString();

            var uriBuilder = new UriBuilder
            {
                Scheme = Request.Scheme,
                Host = Request.Host.ToString(),
                Path = $"/user/ResetPassword/{resetCode}"
            };

            var link = uriBuilder.ToString();

            if (await _repositoryRegistration.SendPasswordResetLinkEmail(email, link) == "Password reset link has been sent to your email...")
            {
                return Ok("Password reset link has been sent to your email...");
            }
            else
            {
                return NotFound("User not found...");
            }

        }

        // POST: api/ForgotPassword
        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPassword resetPassword)
        {
            if (!ModelState.IsValid)
            {
                BadRequest("Check input fields and try again...");
            }

            if (await _repositoryRegistration.ResetUserPassword(resetPassword) == "New password updated successfully...")
            {
                return Ok("New password updated successfully...");
            }
            else
            {
                return NotFound("Account doesn't exist...");
            }

        }
    }
}