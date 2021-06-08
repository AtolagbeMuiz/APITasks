using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Models
{
    public class LoginUser
    {
        [Key]
        public int UserId { get; set; }

        [FromForm]
        public string Username { get; set; }

        [FromForm]
        public string Password { get; set; }

        [FromHeader]
        public string ApiKey { get; set; }

        public DateTime LoginDate { get; set; }
    }
}
