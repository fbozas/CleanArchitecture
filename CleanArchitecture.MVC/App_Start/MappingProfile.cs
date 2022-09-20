using AutoMapper;
using CleanArchitecture.DataAccess.Entities;
using CleanArchitecture.MVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanArchitecture.MVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Employee, EmployeeDto>();
            Mapper.CreateMap<EmployeeDto, Employee>();

            Mapper.CreateMap<Post, PostDto>();
            Mapper.CreateMap<PostDto, Post>();
        }
    }
}