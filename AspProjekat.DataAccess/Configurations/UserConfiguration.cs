using ASPProjekat.DataAccess.Configurations;
using ASPProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        public override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Surname).IsRequired().HasMaxLength(70);
            builder.HasIndex(x => x.Surname);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(250);
        
            builder.HasOne(x => x.Role).WithMany(x => x.Users)
                                       .HasForeignKey(x => x.RoleId)
                                       .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
