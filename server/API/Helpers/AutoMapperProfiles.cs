using API.DTO;
using API.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles()
        {
         
            CreateMap< TaskData, TaskDTO>()
                .ForMember(dest => dest.TaskType, opt => opt.MapFrom(src=>src.TaskType.Type)).ReverseMap();         

        }
    }
}
