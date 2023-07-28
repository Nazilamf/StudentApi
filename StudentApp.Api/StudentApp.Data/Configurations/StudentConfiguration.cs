using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Data.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
     public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Point).IsRequired().HasColumnType("decimal(5,2)");
            builder.HasOne(x => x.Group).WithMany(x => x.Students).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
