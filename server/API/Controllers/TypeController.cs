using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.BL;
using API.Entities;
using API.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeBL _ItyBL;

        public TypeController(ITypeBL ItyBL)
        {
            _ItyBL = ItyBL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskType>>> GetAllTypes()
        {
            try
            {
                return Ok(await _ItyBL.GetAllTypesAsync());
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

     
    }
}
