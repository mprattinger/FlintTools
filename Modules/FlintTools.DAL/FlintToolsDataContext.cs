using FlintTools.Contracts.Models;
using System.Data.Entity;

namespace FlintTools.DAL
{
    public class FlintToolsDataContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }

        public FlintToolsDataContext() : base("name=FlintTools.DbConnection")
        {

        }
    }
}
