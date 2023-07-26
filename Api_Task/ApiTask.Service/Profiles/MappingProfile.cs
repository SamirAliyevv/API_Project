using ApiTask.core.Entities;
using ApiTask.Service.Dtos.GroupDtos;
using ApiTask.Service.Dtos.StudentDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Service.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile(Microsoft.AspNetCore.Http.IHttpContextAccessor? httpContextAccessor)
        {
            CreateMap<GroupCreatDto, Group>();
            CreateMap<Group, GroupGetDto>();
            CreateMap<Group, GroupGetAllDto>();
            CreateMap<Group, StudentGetDtoGroupIn>();
            CreateMap<StudentCreatDto, Student>();
            CreateMap<Student, StudentGetDto>();
            CreateMap<Student, StudentGetAllDto>();

        }

    }
}
