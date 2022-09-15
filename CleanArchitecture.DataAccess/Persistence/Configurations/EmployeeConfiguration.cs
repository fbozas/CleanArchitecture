using CleanArchitecture.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Persistence.Configurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            // Properties
            Property(e => e.ID)
                .IsRequired();

            Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255);

            Property(e => e.Depid)
                .IsRequired();

            // Relationships
            HasRequired(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.Depid);
        }
    }
}
