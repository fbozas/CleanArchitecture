using AutoMapper;
using CleanArchitecture.DataAccess.Entities;
using CleanArchitecture.DataAccess.Interfaces;
using CleanArchitecture.MVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CleanArchitecture.MVC.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            return Ok(_unitOfWork.Employees
                .GetAll()
                .Select(Mapper.Map<Employee, EmployeeDto>));
        }
    }
}
