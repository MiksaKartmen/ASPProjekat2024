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
    public class GalleryImageConfiguration : EntityConfiguration<GalleryImage>
    {
        public override void ConfigureEntity(EntityTypeBuilder<GalleryImage> builder)
        {
            builder.Property(x => x.Src).IsRequired().HasMaxLength(250);
            
            builder.HasOne(x => x.Gallery).WithMany(x => x.GalleryImages)
                                          .HasForeignKey(x => x.GalleryId)
                                          .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
