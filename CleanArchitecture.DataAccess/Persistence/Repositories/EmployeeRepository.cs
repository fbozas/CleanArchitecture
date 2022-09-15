using CleanArchitecture.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CleanArchitecture.DataAccess.Interfaces;

namespace CleanArchitecture.DataAccess.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Include(e => e.Department);
        }

        public Employee GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Employees.Find(id);
        }

        public void Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _context.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _context.Entry(employee).State = EntityState.Modified;
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            Employee employee = GetById(id);

            if (employee == null)
                throw new Exception("Not found");

            _context.Employees.Remove(employee);
        }

        public IQueryable<Employee> Get()
        {
            return _context.Employees.Include(e => e.Department);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
