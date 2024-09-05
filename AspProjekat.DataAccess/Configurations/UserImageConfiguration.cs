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
    public class UserImageConfiguration : EntityConfiguration<UserImage>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserImage> builder)
        {
            builder.Property(x => x.Src).IsRequired().HasMaxLength(200);

            builder.HasOne(x => x.User).WithMany(x => x.UserImages)
                                       .HasForeignKey(x => x.UserId)
                                       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
