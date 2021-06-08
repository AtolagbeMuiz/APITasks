using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Models
{
    public class FormatToken
    {
        public static Dictionary<string, string> FormattedToken(string token)
        {
            var accessToken = new Dictionary<string, string>
            {
                {"access_token", token},
                {"token_type", "Bearer"},
                {"expires_in", "1590942009"}

            };

            return accessToken;
        }
    }
}
