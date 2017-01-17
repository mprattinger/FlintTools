using System.Collections.Generic;
using System.Linq;
using FlintTools.Contracts.Infrastructure.Extensions;

namespace Tasks.Models
{
    public static class TaskExts
    {
        public static string ToFriendlyString(this TaskStatus status)
        {
            string ret = string.Empty;
            switch (status)
            {
                case TaskStatus.EMPTY:
                    ret = string.Empty;
                    break;
                case TaskStatus.OPEN:
                    ret = "Offen";
                    break;
                case TaskStatus.INPROGRESS:
                    ret = "In Bearbeitung";
                    break;
                case TaskStatus.FINISHED:
                    ret = "Abgeschlossen";
                    break;
                default:
                    ret = string.Empty;
                    break;
            }
            return ret;
        }

        public static List<TaskStatusModel> TaskStatusValues(bool withEmpyLine = false)
        {
            var ret = new List<TaskStatusModel>();

            var stati = GeneralExtensions.GetEnumValues<TaskStatus>();

            foreach (var s in stati)
            {
                var txt = s.ToFriendlyString();
                if (string.IsNullOrEmpty(txt) && withEmpyLine)
                {
                    ret.Add(new TaskStatusModel { Key = s, Description = txt });
                    continue;
                }
                ret.Add(new TaskStatusModel
                {
                    Key = s,
                    Description = s.ToFriendlyString()
                });
            }

            return ret;
        }
    }
}
