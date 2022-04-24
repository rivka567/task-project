using API.Entities;
using API.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DAL
{
    public class TypeDAL:ITypeDAL
    {
        private readonly DataContext _context;

        public TypeDAL(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskType>> GetAllTypesAsync()
        {
            try
            {
                var list = await _context.Types.ToListAsync();
                return list;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
