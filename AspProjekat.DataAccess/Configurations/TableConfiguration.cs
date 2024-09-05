using ASPProjekat.DataAccess.Configurations;
using ASPProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.DataAccess.Configurations
{
    public class TableConfiguration : EntityConfiguration<Table>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Table> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Capacity).IsRequired();
        }
    }
}
