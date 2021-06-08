using APITasks.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APITasks.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;

        public TokenService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public string GetToken(LoginUser loginUser)
        {
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(loginUser);
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public SecurityTokenDescriptor GetTokenDescriptor(LoginUser loginUser)
        {
            const int tokenExpiration = 2;

            byte[] securityKey = Encoding.UTF8.GetBytes(_appSettings.EncryptionKey);
            var symmetricSecurityKey = new SymmetricSecurityKey(securityKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loginUser.ApiKey)
                }),
                Expires = DateTime.UtcNow.AddMinutes(tokenExpiration),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, 
                                                        SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;
        }
    }
}
