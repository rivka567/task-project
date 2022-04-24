using API.Entities;
using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.interfaces
{
     public interface ITaskDAL
    {
        Task<bool> UpdateTask(int id, bool completed);

        Task<bool> DeleteTaskAsync(int id);

        Task<bool> AddTaskAsync(TaskData task); 

        Task<bool> SaveAllAsync();
        Task<PagedList<TaskData>> GetAllTasksAsync(TaskParams taskParams);
        Task<TaskData> GetTaskByIdAsync(int id);

    }
}
