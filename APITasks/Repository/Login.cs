using APITasks.Context;
using APITasks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Repository
{
    public class Login : ILogin
    {
        private ApiTaskDBContext _context;

        public Login(ApiTaskDBContext context)
        {
            _context = context;
        }

        /// <summary>
        ///  This method "LoginUser" checks if a user exists in the RegsterUser table
        ///  if it exists, it saves the login details to the "LoginUser" table and returns true
        ///  if it doesnt exists, it returns false
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public async Task<bool> LoginUser(LoginUser loginUser)
        {
            try
            {
                var usercount = await _context.RegisterUser.Where(user => user.Username == loginUser.Username
                                    && user.Password == PasswordEncryption.HashPassword(loginUser.Password)
                                    && user.ApiKey == loginUser.ApiKey)
                                    .CountAsync();

                if (usercount > 0)
                {
                    var loginUsers = new LoginUser
                    {
                        Username = loginUser.Username,
                        Password = PasswordEncryption.HashPassword(loginUser.Password),
                        ApiKey = loginUser.ApiKey,
                        LoginDate = DateTime.Now
                    };

                    await _context.LoginUser.AddAsync(loginUsers);
                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                var errorMessage = ex.Message.ToString();
                return false;
            }
        }
    }
}
