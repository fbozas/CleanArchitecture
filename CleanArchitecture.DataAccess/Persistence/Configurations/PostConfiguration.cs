using CleanArchitecture.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Persistence.Configurations
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(d => d.ID)
              .IsRequired();

            Property(d => d.Title)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
