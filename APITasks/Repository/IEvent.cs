using APITasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Repository
{
    public interface IEvent
    {
        Task<string> CreateEvent(UserEvents userEvents);
    }
}
