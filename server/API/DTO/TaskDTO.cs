using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public bool RepeatTask { get; set; }
        public TimeSpan TaskTime { get; set; }
        public DateTime DateCompleted { get; set; }
        public bool? TaskCompleted { get; set; }
        public string DescribeTask { get; set; }

    }
}
