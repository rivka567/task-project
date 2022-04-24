using API.Entities;
using API.Helpers;
using API.interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DAL
{
    public class TaskDAL: ITaskDAL
    {
        private readonly  DataContext _context;

        public TaskDAL(DataContext context)
        {
            _context = context;
        }

        public async Task<PagedList<TaskData>> GetAllTasksAsync(TaskParams taskParams)
        {
            DateTime currentDate = DateTime.Now;

            try
            {
                var query = _context.Tasks.Include(c => c.TaskType)
                    .Where(t => t.DateCompleted > currentDate)
                    .AsNoTracking();

                query = taskParams.OrderBy switch
                {
                    "name" => query.OrderBy(t => t.TaskName),
                    "type" => query.OrderBy(t => t.TaskType),
                    "time" => query.OrderBy(t => t.TaskTime),
                    _ => query.OrderBy(t => t.DateCompleted)
                };

                return await PagedList<TaskData>.CreateAsync(query, taskParams.PageNumber, taskParams.PageSize);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        public async Task<TaskData> GetTaskByIdAsync(int id)
        {
            try
            {
                var t = await _context.Tasks.FirstAsync(c => c.Id==id);
                return t;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async  Task<bool> UpdateTask(int id, bool completed)
        {
            try
            {
                TaskData t = await GetTaskByIdAsync(id);
                t.TaskCompleted = completed;
                return await SaveAllAsync();
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public Task<bool> AddTaskAsync(TaskData task)
        {
            
            try
            {
              var t=  _context.Tasks.Add(task);
                return SaveAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          

        }



        public async Task<bool> DeleteTaskAsync(int id)
        {
            try
            {
                var deleteTask = await GetTaskByIdAsync(id);
                _context.Tasks.Remove(deleteTask);
                return  await SaveAllAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

  
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
