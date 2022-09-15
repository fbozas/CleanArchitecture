using CleanArchitecture.DataAccess.Entities;
using CleanArchitecture.DataAccess.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(): base("DefaultConnection")
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
