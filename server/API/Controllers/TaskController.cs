using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.BL;
using API.DAL;
using API.DTO;
using API.Entities;
using API.Helpers;
using API.interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskBL _ItsBL;

        public TaskController(ITaskBL ItsBL)
        {
            _ItsBL = ItsBL;
          
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAllTasks([FromQuery]TaskParams taskParams)
        {

            try
            {
                var tasks = await _ItsBL.GetAllTasksAsync(taskParams);

                Response.AddPaginationHeader(tasks.CurrentPage, tasks.PageSize, tasks.TotalCount, tasks.TotalPages);

                IEnumerable<TaskDTO> tasksres = tasks.TList;

                return Ok(tasksres);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

        }


        [HttpGet]
        [Route("GetTaskById/{id:int}")]
        public async Task<ActionResult<TaskData>> GetTaskById(int id)
        {
            try
            {
                var t = await _ItsBL.GetTaskByIdAsync(id);
                return Ok(t);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

        }


        [HttpPost]
        [Route("AddTask")]
        public async Task<ActionResult<bool>> AddTask([FromBody] TaskData task)
        {
            try
            {
                return Ok(await _ItsBL.AddTaskAsync(task));

            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut]
        [Route("UpdateTask/{id:int}")]
        public async Task<ActionResult<bool>> UpdateTask(int id, [FromBody]bool completed)
        {
            try
            {
                return await _ItsBL.UpdateTask(id, completed);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [HttpGet]
        [Route("DeleteTask/{id:int}")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> DeleteTask(int id,[FromQuery] TaskParams taskParams)
        {
            try
            {
                var tasks= await _ItsBL.DeleteTaskAsync(id, taskParams);
                IEnumerable<TaskDTO> tasksres = tasks.TList;

                return Ok(tasksres);
            }

            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
             
        }


    }
        
}

