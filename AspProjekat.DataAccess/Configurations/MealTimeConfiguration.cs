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
    public class MealTimeConfiguration : EntityConfiguration<MealTime>
    {
        public override void ConfigureEntity(EntityTypeBuilder<MealTime> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.TimeFrom).IsRequired();
            builder.Property(x => x.TimeTo).IsRequired();

            builder.HasIndex(x => x.Name);

        }
    }
}
