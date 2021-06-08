using APITasks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Context
{
    public class ApiTaskDBContext : DbContext
    {
        public ApiTaskDBContext(DbContextOptions<ApiTaskDBContext> options) : base(options)
        {
        }

        public DbSet<RegisterUser> RegisterUser { get; set; }
        public DbSet<LoginUser> LoginUser { get; set; }
        public DbSet<UserEvents> UserEvent { get; set; }
    }
}
