using FlintTools.Contracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlintTools.Contracts.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace FlintTools.DAL.Services.Tasks
{
    public class TasksService : ITasksService
    {
        public async Task<List<TaskItem>> GetAllTasks()
        {
            //var ret = new List<TaskItem>();
            //ret.Add(new TaskItem { Title = "Title 01", Description = "Das ist mein erster Task." });
            //ret.Add(new TaskItem { Title = "Title 02", Description = "Das ist mein erster Task." });
            //ret.Add(new TaskItem { Title = "Title 03", Description = "Das ist mein erster Task." });
            //ret.Add(new TaskItem { Title = "Title 04", Description = "Das ist mein erster Task." });
            //return ret;

            using(var ctx = new FlintToolsDataContext())
            {
                return await ctx.TaskItems.ToListAsync();
            }
        }

        public async Task<bool> AddTask(TaskItem task)
        {
            using (var ctx = new FlintToolsDataContext())
            {
                try
                {
                    ctx.TaskItems.Add(task);
                    await ctx.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    return false;
                }
                return true;
            }
        }
    }
}
