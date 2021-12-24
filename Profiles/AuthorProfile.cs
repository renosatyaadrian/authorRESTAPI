using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authorRESTAPI.Dtos;
using authorRESTAPI.Models;
using AutoMapper;

namespace authorRESTAPI.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest=>dest.Name, opt=>opt.MapFrom(src=>$"{src.FirstName} {src.LastName}"));
            
            CreateMap<AuthorForUpdateDto, Author>();
        }
    }
}