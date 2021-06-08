using APITasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks
{
    public interface IRegistration
    {
        Task<bool> RegisterUser(RegisterUser registerUser);
        Task<string> SendPasswordResetLinkEmail(string email, string link);
        Task<string> ResetUserPassword(ResetPassword resetPassword);
    }
}
