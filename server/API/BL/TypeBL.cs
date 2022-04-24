using API.DAL;
using API.Entities;
using API.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.BL
{
    public class TypeBL:ITypeBL
    {
        private readonly ITypeDAL _ItyDAL;

        public TypeBL(ITypeDAL ItyDAL)
        {
            _ItyDAL = ItyDAL;
        }

        public async Task<IEnumerable<TaskType>> GetAllTypesAsync()
        {
            try
            {
                return await _ItyDAL.GetAllTypesAsync();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
