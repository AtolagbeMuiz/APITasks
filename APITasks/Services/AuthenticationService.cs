using APITasks.Models;
using APITasks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogin _repositoryLogin;
        private readonly ITokenService _repositoryTokenService;

        public AuthenticationService(ILogin repositoryLogin, ITokenService repositoryTokenService)
        {
            _repositoryLogin = repositoryLogin;
            _repositoryTokenService = repositoryTokenService;
        }


        /// <summary>
        /// Thi autheticates a user and generates a token for such user
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public async Task<string> Authenticate(LoginUser loginUser)
        {
            try
            {
                string securityToken = _repositoryTokenService.GetToken(loginUser);
                return securityToken;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message.ToString();
                return errorMessage;
            }
        }
    }
}
