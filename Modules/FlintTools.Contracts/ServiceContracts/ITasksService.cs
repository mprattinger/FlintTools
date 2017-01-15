using FlintTools.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintTools.Contracts.ServiceContracts
{
    public interface ITasksService
    {
        Task<List<TaskItem>> GetAllTasks();
        Task<bool> AddTask(TaskItem task);
    }
}
