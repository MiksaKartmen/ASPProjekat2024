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
    public class GalleryConfiguration : EntityConfiguration<Gallery>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Gallery> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Title);
        }
    }
}
