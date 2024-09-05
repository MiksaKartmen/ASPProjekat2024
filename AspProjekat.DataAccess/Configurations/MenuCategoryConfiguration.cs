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
    public class MenuCategoryConfiguration : EntityConfiguration<MenuCategory>
    {
        public override void ConfigureEntity(EntityTypeBuilder<MenuCategory> builder)
        {
            builder.HasIndex(x => x.Name);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            
            builder.HasOne(x => x.Parent).WithMany(x => x.Children)
                                         .HasForeignKey(x => x.SubCategory)
                                         .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
