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

        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            if (employee == null)
                return NotFound();

            return Ok(Mapper.Map<Employee, EmployeeDto>(employee));
        }

        [HttpPost]
        public IHttpActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = Mapper.Map<EmployeeDto, Employee>(employeeDto);
            _unitOfWork.Employees.Create(employee);
            _unitOfWork.Complete();
            employeeDto.ID = employee.ID;
            return Created(new Uri(Request.RequestUri + "/" + employee.ID), employeeDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employeeInDb = _unitOfWork.Employees.GetById(id);

            if (employeeInDb == null)
                return NotFound();

            Mapper.Map(employeeDto, employeeInDb);
            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _unitOfWork.Employees.GetById(id);

            if (employeeInDb == null)
                return NotFound();

            _unitOfWork.Employees.Delete(id);
            _unitOfWork.Complete();

            return Ok(employeeInDb);
        }
    }
}
