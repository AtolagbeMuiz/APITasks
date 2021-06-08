using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Models
{
    public class RegisterUser
    {
        [Key]
        public int UserId { get; set; }

        [FromForm]
        [Required(ErrorMessage = "Username is required...")]
        public string Username { get; set; }

        [FromForm]
        [Required(ErrorMessage = "Password is required...")]
        public string Password { get; set; }

        [FromForm]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Email format is wrong...")]
        [Required(ErrorMessage = "Email is required...")]
        public string Email { get; set; }

        [FromHeader]
        [Required(ErrorMessage = "ApiKey is required...")]
        public string ApiKey { get; set; }

        public DateTime SignupDate { get; set; } //= DateTime.Now;
    }
}
