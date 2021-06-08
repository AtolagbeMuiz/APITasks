using APITasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Services
{
    public interface IAuthenticationService
    {
        Task<string> Authenticate(LoginUser loginUser);
    }
}
