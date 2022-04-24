using API.DTO;
using API.Entities;
using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.interfaces
{
   public interface ITaskBL
    {
          Task<PagedList<TaskDTO>> GetAllTasksAsync(TaskParams taskParams);

         Task<TaskData> GetTaskByIdAsync(int id);

         Task<bool> AddTaskAsync(TaskData task);

        Task<PagedList<TaskDTO>> DeleteTaskAsync(int id, TaskParams taskParams);

        Task<bool> UpdateTask(int id, bool completed);

        
    }
}
