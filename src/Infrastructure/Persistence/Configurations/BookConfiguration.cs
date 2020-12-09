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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Title)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(t => t.Isbn)
               .HasMaxLength(50)
               .IsRequired();
        }
    }
}
