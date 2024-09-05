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
    public class MenuItemConfiguration : EntityConfiguration<MenuItem>
    {
        public override void ConfigureEntity(EntityTypeBuilder<MenuItem> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);

            builder.HasIndex(x => x.Name);

            builder.HasOne(x => x.MenuCategory).WithMany(x => x.MenuItems)
                                               .HasForeignKey(x => x.MenuCategoryId)
                                               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
