using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task Execute(string email, string subject, string message);

        //Task Execute(string apiKey, string subject, string message, string email);

    }
}
