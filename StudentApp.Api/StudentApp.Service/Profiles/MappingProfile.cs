using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudentApp.Core.Entities;
using StudentApp.Service.Dtos.GroupDtos;
using StudentApp.Service.Dtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Service.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile(IHttpContextAccessor _httpContextAccessor)

        {
            var baseUrl = new UriBuilder(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Host, _httpContextAccessor.HttpContext.Request.Host.Port ?? -1);

            CreateMap<GroupCreateDto, Group>();
            CreateMap<Group, GroupGetDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<Student, StudentGetDto>();
        }
    }
}
