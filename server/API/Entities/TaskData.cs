using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class TaskData
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public virtual TaskType TaskType { get; set; }
        public int TaskTypeId { get; set; }
        public bool RepeatTask { get; set; }
        public TimeSpan TaskTime { get; set; }
        public DateTime DateCompleted { get; set; }
        public bool? TaskCompleted { get; set; }
        public string DescribeTask { get; set; }

        public static implicit operator TaskData(EntityEntry<TaskData> v)
        {
            throw new NotImplementedException();
        }
    }
}
