using CleanArchitecture.DataAccess.Interfaces;
using CleanArchitecture.DataAccess.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IDepartmentRepository Departments { get; private set; }
        public IEmployeeRepository Employees { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Departments = new DepartmentRepository(_context);
            Employees = new EmployeeRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
