using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{

    public class TaskType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual List<TaskData> TaskData { get; set; }
    }
}
