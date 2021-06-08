using APITasks.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Services
{
    public interface ITokenService
    {
        string GetToken(LoginUser loginUser);
        SecurityTokenDescriptor GetTokenDescriptor(LoginUser loginUser);
    }
}
