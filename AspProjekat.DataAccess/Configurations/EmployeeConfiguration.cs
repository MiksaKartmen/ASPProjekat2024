using ASPProjekat.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Domain.Configurations
{
    public class EmployeeConfiguration : EntityConfiguration<Employee>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Biography).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(250);
            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Surname);

            builder.HasOne(x => x.EmployeeRole).WithMany(x => x.Employees)
                                               .HasForeignKey(x => x.EmployeeRoleId)
                                               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
