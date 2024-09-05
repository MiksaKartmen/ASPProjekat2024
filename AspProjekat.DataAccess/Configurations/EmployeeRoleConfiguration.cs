
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
    public class EmployeeRoleConfiguration : EntityConfiguration<EmployeeRole>
    {
        public override void ConfigureEntity(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
