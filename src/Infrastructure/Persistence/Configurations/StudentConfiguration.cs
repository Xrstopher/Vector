using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Domain.Entities;

namespace Vector.Infrastructure.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.MiddleName)
              .HasMaxLength(50);

            builder.Property(t => t.LastName)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(t => t.Email)
              .IsRequired();
        }
    }
}
