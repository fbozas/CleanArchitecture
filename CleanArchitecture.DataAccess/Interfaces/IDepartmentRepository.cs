using CleanArchitecture.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.DataAccess.Interfaces
{
    public interface IDepartmentRepository : IDisposable
    {
        IEnumerable<Department> GetAll();
    }
}