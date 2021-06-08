using APITasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Repository
{
    public interface ILogin
    {
        Task<bool> LoginUser(LoginUser loginUser);
    }
}
