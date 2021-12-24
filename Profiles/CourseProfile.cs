using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authorRESTAPI.Dtos;
using authorRESTAPI.Models;
using AutoMapper;

namespace authorRESTAPI.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(des=>des.AuthorID, opt=>opt.MapFrom(src=> src.Enrollments));
            CreateMap<CourseForUpdateDto, Course>();
            
        }
    }
}