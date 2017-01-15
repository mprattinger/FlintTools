using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlintTools.Contracts.Models
{
    public class TaskItem
    {
        [Key]
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Description { get; set; }

        public string State { get; set; }
    }
}
