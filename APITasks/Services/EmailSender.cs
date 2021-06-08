using APITasks.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace APITasks.Services
{
    public class EmailSender : IEmailSender
    {
        //private readonly IConfiguration _config;

        private readonly SMTPConfigModel _config;

        public EmailSender(IOptions<SMTPConfigModel> options)
        {
            this._config = options.Value;
           //config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            await Execute(email, subject, message);
        }

        public async Task Execute(string email, string subject, string message)
        {
            MailMessage mail = new MailMessage
            {
                Subject = subject,
                Body = message,
                From = new MailAddress(_config.SenderAddress, _config.SenderDisplayName),
                IsBodyHtml = _config.IsBodyHtml
            };

            NetworkCredential networkCredentials = new NetworkCredential(_config.Username, _config.Password);

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _config.Host,
                Port = _config.Port,
                EnableSsl = _config.EnableSSL,
                Credentials = networkCredentials
            };

            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);
        }



        //public async Task SendEmailAsync(string email, string subject, string message)
        //{
        //    await Execute(_config.GetSection("SendGridAPI:SendGridKey").Value, subject, message, email);
        //}

        //public async Task Execute(string apiKey, string subject, string message, string email)
        //{
        //    var client = new SendGridClient(apiKey);
        //    var msg = new SendGridMessage()
        //    {
        //        From = new EmailAddress("franklinezeji@gmail.com", _config.GetSection("SendGridAPI:SendGridUser").Value),
        //        Subject = subject,
        //        HtmlContent = message
        //    };
        //    msg.AddTo(new EmailAddress(email));

        //    // Disable click tracking.
        //    // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        //    msg.SetClickTracking(false, false);

        //    var response = await client.SendEmailAsync(msg);
        //}
    }
}
