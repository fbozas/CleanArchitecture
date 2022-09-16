using CleanArchitecture.DataAccess.Interfaces;
using System;

namespace CleanArchitecture.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Departments { get; }
        IEmployeeRepository Employees { get; }

        void Complete();
    }
}