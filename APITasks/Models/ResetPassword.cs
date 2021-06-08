using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Models
{
    public class ResetPassword
    {
        [FromForm]
        [Required(ErrorMessage = "Email is required...")]
        public string Email { get; set; }

        [FromForm]
        [Required(ErrorMessage = "New password is required...", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [FromForm]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New password and confirm password does not match...")]
        public string ConfirmPassword { get; set; }
    }
}
