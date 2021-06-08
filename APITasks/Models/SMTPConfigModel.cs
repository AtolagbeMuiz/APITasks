using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Models
{
    public class SMTPConfigModel
    {
        public string SenderAddress { get; set; }
        public string SenderDisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public string UseDefaultCredentials { get; set; }
        public bool EnableSSL { get; set; }
        public bool IsBodyHtml { get; set; } = true;

    }
}
