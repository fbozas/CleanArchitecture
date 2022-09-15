using CleanArchitecture.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.DataAccess.Interfaces
{
    public interface IEmployeeRepository : IDisposable
    {
        void Create(Employee employee);
        void Delete(int? id);
        IQueryable<Employee> Get();
        IEnumerable<Employee> GetAll();
        Employee GetById(int? id);
        void Update(Employee employee);
    }
}