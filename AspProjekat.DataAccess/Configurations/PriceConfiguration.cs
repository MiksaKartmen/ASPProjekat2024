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
    public class PriceConfiguration : EntityConfiguration<Price>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Price> builder)
        {
            builder.Property(x => x.Ammount).IsRequired().HasDefaultValue(0);

            builder.HasOne(x => x.MenuItem).WithMany(x => x.Prices)
                                           .HasForeignKey(x => x.MenuItemId)
                                           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
