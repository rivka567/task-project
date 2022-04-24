using API.DAL;
using API.DTO;
using API.Entities;
using API.Helpers;
using API.interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.BL
{
    public class TaskBL : ITaskBL
    {
        private readonly ITaskDAL _ItsDAL;
        private readonly IMapper _mapper;

        public TaskBL(ITaskDAL Its, IMapper mapper)
        {
            _ItsDAL = Its;
            _mapper = mapper;
        }

        public async Task<PagedList<TaskDTO>> GetAllTasksAsync(TaskParams taskParams)
        {
         
            try
            {
                var result = await _ItsDAL.GetAllTasksAsync(taskParams);
                var tlist = _mapper.Map<List<TaskDTO>>(result).ToList();

                PagedList<TaskDTO> res = new PagedList<TaskDTO>(tlist);
                res.TotalCount = result.TotalCount;
                res.TotalPages = result.TotalPages;
                res.PageSize = result.PageSize;
                res.CurrentPage = result.CurrentPage;
                res.TList = tlist;
                return res;
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
                var result = await _ItsDAL.GetTaskByIdAsync(id);
                return result;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddTaskAsync(TaskData task)
        {
            try
            {
                return await _ItsDAL.AddTaskAsync(task);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<PagedList<TaskDTO>> DeleteTaskAsync(int id,TaskParams taskParams)
        {
            try
            {
                if(await _ItsDAL.DeleteTaskAsync(id))
                {
                    var result = await GetAllTasksAsync(taskParams);
                    return result;
                }
                          
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
         

        }

        public async Task<bool> UpdateTask(int id, bool completed)
        {
            try
            {
                return await _ItsDAL.UpdateTask(id, completed);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
